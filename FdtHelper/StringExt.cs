namespace DtsTools
{
	public static class StringExt
	{
		public static int Count(this string txt, char ch)
		{
			var cnt = 0;
			var p = 0;
			while (p < txt.Length)
			{
				if(txt[p] == ch)
				{
					cnt++;
				}
				p++;
			}
			return cnt;
		}

		public static bool MoveTo(this string txt, ref int p, string value, MoveStrategy strategy, char stopChar = '\0')
		{
			var matched = false;
			var i = p + 1;
			var j = 0;

			switch (strategy)
			{
				case MoveStrategy.AllAllowed:
					while (i < txt.Length)
					{
						if (txt[i] == value[j])
						{
							if (j == value.Length - 1)
							{
								matched = true;
								break;
							}
							j++;
						}
						else
						{
							j = 0;
						}
						i++;
					}
					if (i < txt.Length && matched && (txt[i] == ';' || char.IsWhiteSpace(txt[i + 1]) || txt[i + 1] == ';'))
					{
						p = ++i;
						return true;
					}
					return false;
				case MoveStrategy.OnlyWhitespacesAllowed:
					while (i < txt.Length)
					{
						if (txt[i] == value[j])
						{
							if (j == value.Length - 1)
							{
								matched = true;
								break;
							}
							j++;
						}
						else
						{
							if (!char.IsWhiteSpace(txt[i])) break;
							j = 0;
						}
						i++;
					}
					if (i < txt.Length && matched && (txt[i] == ';' || char.IsWhiteSpace(txt[i + 1]) || txt[i + 1] == ';'))
					{
						p = ++i;
						return true;
					}
					return false;
				case MoveStrategy.AllButNewlinesAllowed:
					while (i < txt.Length)
					{
						if (txt[i] == value[j])
						{
							if (j == value.Length - 1)
							{
								matched = true;
								break;
							}
							j++;
						}
						else
						{
							if (txt[i] == '\r' || txt[i] == '\n') break;
							j = 0;
						}
						i++;
					}
					if (i < txt.Length && matched && (txt[i] == ';' || char.IsWhiteSpace(txt[i + 1]) || txt[i + 1] == ';'))
					{
						p = ++i;
						return true;
					}
					return false;
				case MoveStrategy.AllButWhitespacesAllowed:
					while (i < txt.Length)
					{
						if (txt[i] == value[j])
						{
							if (j == value.Length - 1)
							{
								matched = true;
								break;
							}
							j++;
						}
						else
						{
							if (char.IsWhiteSpace(txt[i])) break;
							j = 0;
						}
						i++;
					}
					if (i < txt.Length && matched && (txt[i] == ';' || char.IsWhiteSpace(txt[i + 1]) || txt[i + 1] == ';'))
					{
						p = ++i;
						return true;
					}
					return false;
				case MoveStrategy.ImmediateValue:
					while (i < txt.Length)
					{
						if (txt[i] == value[j])
						{
							if (j == value.Length - 1)
							{
								matched = true;
								break;
							}
							j++;
						}
						else
						{
							break;
						}
						i++;
					}
					if (i < txt.Length && matched && (txt[i] == ';' || char.IsWhiteSpace(txt[i + 1]) || txt[i + 1] == ';'))
					{
						p = ++i;
						return true;
					}
					return false;
				case MoveStrategy.UntilNewline:
					while (i < txt.Length)
					{
						if (txt[i] == '\r' || txt[i] == '\n' || i == txt.Length - 1)
						{
							matched = true;
							break;
						}
						i++;
					}
					if (i < txt.Length && matched)
					{
						p = ++i;
						return true;
					}
					return false;
				case MoveStrategy.UntilChar:
					while (i < txt.Length)
					{
						if (txt[i] == value[j])
						{
							if (j == value.Length - 1)
							{
								matched = true;
								break;
							}
							j++;
						}
						else
						{
							if (txt[i] == stopChar) break;
							j = 0;
						}
						i++;
					}
					if (i < txt.Length && matched && (txt[i] == ';' || char.IsWhiteSpace(txt[i + 1]) || txt[i + 1] == ';'))
					{
						p = ++i;
						return true;
					}
					return false;
				default:
					return false;
			}
		}

		public static bool MoveFrom(this string txt, ref int p, string value, MoveStrategy strategy, char stopChar = '\0')
		{
			var matched = false;
			var i = p - 1;
			var j = value.Length - 1;

			switch (strategy)
			{
				case MoveStrategy.AllAllowed:
					while (i >= 0)
					{
						if (txt[i] == value[j])
						{
							if (j == 0)
							{
								matched = true;
								break;
							}
							j--;
						}
						else
						{
							j = value.Length - 1;
						}
						i--;
					}
					if (i >= 0 && matched && (char.IsWhiteSpace(txt[i - 1]) || txt[i] == ';' || txt[i - 1] == ';'))
					{
						p = --i;
						return true;
					}
					return false;
				case MoveStrategy.OnlyWhitespacesAllowed:
					while (i >= 0)
					{
						if (txt[i] == value[j])
						{
							if (j == 0)
							{
								matched = true;
								break;
							}
							j--;
						}
						else
						{
							if (!char.IsWhiteSpace(txt[i])) break;
							j = value.Length - 1;
						}
						i--;
					}
					if (i >= 0 && matched && (char.IsWhiteSpace(txt[i - 1]) || txt[i - 1] == ';'))
					{
						p = --i;
						return true;
					}
					return false;
				case MoveStrategy.AllButNewlinesAllowed:
					while (i >= 0)
					{
						if (txt[i] == value[j])
						{
							if (j == 0)
							{
								matched = true;
								break;
							}
							j--;
						}
						else
						{
							if (txt[i] == '\r' || txt[i] == '\n') break;
							j = value.Length - 1;
						}
						i--;
					}
					if (i >= 0 && matched && (char.IsWhiteSpace(txt[i - 1]) || txt[i - 1] == ';'))
					{
						p = --i;
						return true;
					}
					return false;
				case MoveStrategy.ImmediateValue:
					while (i >= 0)
					{
						if (txt[i] == value[j])
						{
							if (j == 0)
							{
								matched = true;
								break;
							}
							j--;
						}
						else
						{
							break;
						}
						i--;
					}
					if (i >= 0 && matched && (char.IsWhiteSpace(txt[i - 1]) || txt[i - 1] == ';'))
					{
						p = --i;
						return true;
					}
					return false;
				case MoveStrategy.UntilNewline:
					while (i >= 0)
					{
						if (txt[i] == '\r' || txt[i] == '\n')
						{
							matched = true;
							break;
						}
						i--;
					}
					if (i >= 0 && matched)
					{
						p = --i;
						return true;
					}
					return false;
				default:
					return false;
			}
		}

		public static bool PeekNext(this string txt, int p, char ch)
		{
			return p + 1 < txt.Length && txt[p + 1] == ch;
		}
	}
}