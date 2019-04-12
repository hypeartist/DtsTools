using System.Text.RegularExpressions;

namespace DtsTools
{
	public class NodeProperty
	{
		public NodeProperty(string name, string value)
		{
			Name = name;
			Value = value;
		}

		public string Name { get; }

		public string Value { get; }

		public override string ToString()
		{
			return string.IsNullOrEmpty(Value) ? Name : $"{Name} = {Regex.Replace(Value, @"\s+", " ")}";
		}
	}
}