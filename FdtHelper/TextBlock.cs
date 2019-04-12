namespace DtsTools
{
	public class TextBlock
	{
		public static readonly TextBlock LineBreak = new TextBlock(null, BlockType.LineBreak);

		public TextBlock(string content, BlockType type)
		{
			Content = content;
			Type = type;
		}

		public string Content { get; }

		public BlockType Type { get; }
	}
}