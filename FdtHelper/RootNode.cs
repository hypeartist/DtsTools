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
			private Node _node;
			private OverlayType _type;
			private NodeProperty _property;

			public static OverlayItem AddNode(Node node)
			{
				return new OverlayItem {_type = OverlayType.AddNode, _node = node};
			}

			public static OverlayItem DeleteNode(Node node)
			{
				return new OverlayItem {_type = OverlayType.DeleteNode, _node = node};
			}

			public static OverlayItem SetProperty(Node node, NodeProperty property)
			{
				return new OverlayItem {_type = OverlayType.SetProperty, _node = node, _property = property};
			}

			public static OverlayItem DeleteProperty(Node node, NodeProperty property)
			{
				return new OverlayItem {_type = OverlayType.DeleteProperty, _node = node, _property = property};
			}

			public string Location
			{
				get
				{
					switch (_type)
					{
						case OverlayType.AddNode:
						case OverlayType.DeleteNode:
							return _node.Location;
						case OverlayType.SetProperty:
						case OverlayType.DeleteProperty:
							return string.IsNullOrEmpty(_node.Label) ? $"{_node.Location}|{_node.Name}" : $"&{_node.Label}";

						default:
							throw new ArgumentOutOfRangeException();
					}
				}
			}

			public string Dump(List<OverlayItem> others = null)
			{
				var hops = Location.Split('|');
				var output = "";
				var indent = "";
				for (var i = 0; i < hops.Length; i++)
				{
					for (var j = 0; j < i; j++)
					{
						indent += '\t';
					}

					output += $"{indent}{hops[i]} {{\n";
				}

				indent += "\t";

				output += DumpBody(indent, others);

				indent = indent.Remove(indent.Length - 1);
				for (var i = 0; i < hops.Length; i++)
				{
					for (var j = 0; j < i; j++)
					{
						indent = indent.Remove(indent.Length - 1);
					}

					output += $"{indent}}};\n";
				}

				return output;
			}

			private string DumpBody(string indent, List<OverlayItem> others = null)
			{
				var output = "";
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
						DumpNode(_node);
						break;
					case OverlayType.DeleteNode:
						output += $"{indent}/delete-node/ {_node.Name};\n";
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

			foreach (var kv in _pathMap)
			{
				var srcNodePath = kv.Key;
				var srcNode = kv.Value;

				if (!target._pathMap.ContainsKey(srcNodePath))
				{
					overlayItems.Add(OverlayItem.AddNode(srcNode));
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
					overlayItems.Add(OverlayItem.DeleteNode(targetNode));
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

			var dump = "";

			for (var i = 0; i < overlayItems.Count; i++)
			{
				var item = overlayItems[i];
				var itemsAtSameLocation = overlayItems.Where(o => o != item && o.Location == item.Location).ToList();
				foreach (var oi in itemsAtSameLocation)
				{
					overlayItems.Remove(oi);
				}

				dump += item.Dump(itemsAtSameLocation);
			}

			return dump;
		}
	}
}