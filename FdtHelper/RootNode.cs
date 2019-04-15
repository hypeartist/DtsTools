using System;
using System.Collections.Generic;
using System.Linq;

namespace DtsTools
{
	public class RootNode : Node
	{
		private readonly Dictionary<string, Node> _labelMap = new Dictionary<string, Node>();
		private readonly Dictionary<string, Node> _pathMap = new Dictionary<string, Node>();

		public RootNode() : base(null, "root", "root")
		{
			Root = this;
		}

		public Node FindNodeByLabel(string label)
		{
			return _labelMap.ContainsKey(label) ? _labelMap[label] : null;
		}

		public Node FindNodeByPath(string path)
		{
			return _pathMap.ContainsKey(path) ? _pathMap[path] : null;
		}

		public void DeleteNode(Node node)
		{
			_labelMap.Remove(node.Label);
			_pathMap.Remove(node.Path);
		}

		internal void Register(Node node)
		{
			if (!string.IsNullOrEmpty(node.Label))
			{
				if (!_labelMap.ContainsKey(node.Label))
				{
					_labelMap.Add(node.Label, node);
				}
			}

			if (!_pathMap.ContainsKey(node.Path))
			{
				_pathMap.Add(node.Path, node);
			}
		}

		private enum OverlayType
		{
			AddNode,
			DeleteNode,
			SetProperty,
			DeleteProperty
		}

		private class OverlayItem
		{
			private OverlayType _type;
			private NodeProperty _property;

			public static OverlayItem AddNode(Node node)
			{
				return new OverlayItem {_type = OverlayType.AddNode, Node = node};
			}

			public static OverlayItem DeleteNode(Node node)
			{
				return new OverlayItem {_type = OverlayType.DeleteNode, Node = node};
			}

			public static OverlayItem SetProperty(Node node, NodeProperty property)
			{
				return new OverlayItem {_type = OverlayType.SetProperty, Node = node, _property = property};
			}

			public static OverlayItem DeleteProperty(Node node, NodeProperty property)
			{
				return new OverlayItem {_type = OverlayType.DeleteProperty, Node = node, _property = property};
			}

			public string Location
			{
				get
				{
					switch (_type)
					{
						case OverlayType.AddNode:
						case OverlayType.DeleteNode:
							return Node.Location;
						case OverlayType.SetProperty:
						case OverlayType.DeleteProperty:
							return string.IsNullOrEmpty(Node.Label) ? string.IsNullOrEmpty(Node.Location) ? Node.Name : $"{Node.Location}|{Node.Name}" : $"&{Node.Label}";

						default:
							throw new ArgumentOutOfRangeException();
					}
				}
			}

			public Node Node { get; private set; }

			public string Dump(List<OverlayItem> others = null)
			{
				var hops = Location.Split('|');
				var output = string.Empty;
				var indent = string.Empty;
				for (var i = 0; i < hops.Length; i++)
				{
					output += $"{indent}{hops[i]} {{\n";
					indent += '\t';
				}

				output += DumpBody(indent, others);

				for (var i = 0; i < hops.Length; i++)
				{
					indent = indent.Remove(indent.Length - 1);
					output += $"{indent}}};\n";
				}

				return output;
			}

			private string DumpBody(string indent, List<OverlayItem> others = null)
			{
				var output = string.Empty;
				switch (_type)
				{
					case OverlayType.AddNode:
						void DumpNode(Node node)
						{
							output += $"{indent}{node} {{\n";
							indent += "\t";
							foreach (var kv in node.Properties)
							{
								output += $"{indent}{kv.Value};\n";
							}
							foreach (var childNode in node.ChildNodes)
							{
								DumpNode(childNode);
							}
							indent = indent.Remove(indent.Length - 1);
							output += $"{indent}}};\n";
						}
						DumpNode(Node);
						break;
					case OverlayType.DeleteNode:
						output += $"{indent}/delete-node/ {Node.Name};\n";
						break;
					case OverlayType.SetProperty:
						output += $"{indent}{_property};\n";
						break;
					case OverlayType.DeleteProperty:
						output += $"{indent}/delete-property/ {_property.Name};\n";
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				if (others == null)
				{
					return output;
				}

				foreach (var other in others)
				{
					output += other.DumpBody(indent);
				}

				return output;
			}
		}

		public string Overlay(RootNode target)
		{
			var overlayItems = new List<OverlayItem>();
			var nodesToDelete = new List<OverlayItem>();
			var nodesToAdd = new List<OverlayItem>();

			foreach (var kv in _pathMap)
			{
				var srcNodePath = kv.Key;
				var srcNode = kv.Value;
				if (!target._pathMap.ContainsKey(srcNodePath))
				{
					var item = OverlayItem.AddNode(srcNode);
					overlayItems.Add(item);
					nodesToAdd.Add(item);
					continue;
				}

				var targetNode = target._pathMap[srcNodePath];
				foreach (var kv0 in kv.Value.Properties)
				{
					var srcPropName = kv0.Key;
					var srcProp = kv0.Value;

					if (!targetNode.Properties.ContainsKey(srcPropName) || srcProp.Value != targetNode.Properties[srcPropName].Value)
					{
						overlayItems.Add(OverlayItem.SetProperty(srcNode, srcProp));
					}
				}
			}

			foreach (var kv in target._pathMap)
			{
				var targetNodePath = kv.Key;
				var targetNode = kv.Value;

				if (!_pathMap.ContainsKey(targetNodePath))
				{
					var item = OverlayItem.DeleteNode(targetNode);
					overlayItems.Add(item);
					nodesToDelete.Add(item);
					continue;
				}

				var srcNode = _pathMap[kv.Key];
				foreach (var kv0 in kv.Value.Properties)
				{
					var targetPropName = kv0.Key;
					var targetProp = kv0.Value;

					if (!srcNode.Properties.ContainsKey(targetPropName))
					{
						overlayItems.Add(OverlayItem.DeleteProperty(targetNode, targetProp));
					}
				}
			}

			var processedItems = new List<OverlayItem>();
			var delayedItems = new List<OverlayItem>();
			var dump = "";

			for (var i = 0; i < overlayItems.Count; i++)
			{
				var item = overlayItems[i];
				if(nodesToDelete.Any(di => item.Node.IsDescendantOf(di.Node)) || nodesToAdd.Any(di => item.Node.IsDescendantOf(di.Node))) continue;

				var itemsAtSameLocation = overlayItems.Where(o => o != item && o.Location == item.Location).ToList();
				foreach (var oi in itemsAtSameLocation)
				{
					overlayItems.Remove(oi);
				}

				// if(!string.IsNullOrEmpty(item._node.Label) && !processedItems.Contains())

				dump += item.Dump(itemsAtSameLocation);
				// processedItems.Add(item);
				// processedItems.AddRange(itemsAtSameLocation);
			}

			return dump;
		}
	}
}