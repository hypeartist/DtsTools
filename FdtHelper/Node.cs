using System.Collections.Generic;

namespace DtsTools
{
	public class Node
	{
		private readonly List<Node> _childNodes = new List<Node>();
		private readonly Dictionary<string, NodeProperty> _properties = new Dictionary<string, NodeProperty>();
		private readonly int _level;

		private protected Node(Node parent, string name, string label)
		{
			Parent = parent;
			Name = name;
			Label = label;
			if (parent == null)
			{
				_level = -1;
				Path = "";
			}
			else
			{
				_level = parent._level + 1;
				Path = parent.Name == "root" ? name : $"{parent.Path}|{name}";	
			}
		}

		public string Name { get; }

		public string Label { get; private set; }

		public string Path { get; }

		public RootNode Root { get; protected set; }

		public IReadOnlyDictionary<string, NodeProperty> Properties => _properties;

		public IReadOnlyList<Node> ChildNodes => _childNodes;
		
		public Node Parent { get; }

		public string Location
		{
			get
			{
				var path = "";
				var parent = Parent;
				while (parent != null && parent.Name != "root")
				{
					if (!string.IsNullOrEmpty(parent.Label))
					{
						path = string.IsNullOrEmpty(path) ? $"&{parent.Label}" : $"&{parent.Label}|{path}";
						break;
					}

					path = string.IsNullOrEmpty(path) ? $"{parent.Name}" : $"{parent.Name}|{path}";
					parent = parent.Parent;
				}

				return path;
			}
		}

		public Node AddChild(string name, string label)
		{
			if (name.StartsWith("&"))
			{
				label = name.TrimStart('&');
				name = label;
			}
			var existing = Root.FindNodeByLabel(label);
			if (existing == null)
			{
				var path = string.IsNullOrEmpty(Path) ? name : $"{Path}|{name}";
				existing = Root.FindNodeByPath(path);
			}

			if (existing != null)
			{
				if (string.IsNullOrEmpty(existing.Label) && !string.IsNullOrEmpty(label))
				{
					existing.Label = label;
					Root.Register(existing);
				}
				return existing;
			}
			var node = new Node(this, name, label);
			_childNodes.Add(node);
			node.Root = Root;
			Root.Register(node);
			return node;
		}

		public void AddProperty(NodeProperty prop)
		{
			if (prop.Name.StartsWith("/delete-node/"))
			{
				var node = Root.FindNodeByPath($"{Path}|{prop.Name.Replace("/delete-node/", "")}");
				node.Parent._childNodes.Remove(node);
				Root.DeleteNode(node);
				return;
			}
			_properties[prop.Name] = prop;
		}

		public override string ToString()
		{
			return string.IsNullOrEmpty(Label) ? Name : $"{Label}: {Name}";
		}

		public string Dump()
		{
			if (Parent == null)
			{
				return _childNodes[0].Dump();
			}
			var indent = "";
			for (var i = 0; i < _level; i++)
			{
				indent += '\t';
			}

			var dump = $"\n{Path}\n\n";
			dump += $"{indent}{this} {{\n";
			var innerIndent = indent + '\t';

			foreach (var kv in _properties)
			{
				var prop = _properties[kv.Key];
				dump += $"{innerIndent}{prop};\n";
			}

			if (_childNodes.Count > 0)
			{
				dump += '\n';
				for (var i = 0; i < _childNodes.Count; i++)
				{
					var node = _childNodes[i];
					dump += $"{node.Dump()}";
				}
			}

			dump += $"{indent}}};\n";
			return dump;
		}
	}
}