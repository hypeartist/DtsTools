namespace DtsTools
{
	public enum MoveStrategy
	{
		AllAllowed,
		OnlyWhitespacesAllowed,
		AllButNewlinesAllowed,
		AllButWhitespacesAllowed,
		ImmediateValue,
		UntilNewline,
		UntilChar
	}
}