using System;
using System.Collections.Generic;
using System.IO;

namespace DtsTools
{
	public class DtsProcessor
	{
		private readonly string _workingFolder;
		private readonly string _textData;
		private readonly List<string> _processedFiles;
		private readonly int _textDataLength;
		private int _positionInText;
		private readonly Node _rootNode;

		private DtsProcessor(string workingFolder, string textData, Node parent, List<string> processedFiles)
		{
			_rootNode = parent ?? new RootNode();
			textData = textData.Trim();
			var pos = 0;
			var length = textData.Length;
			while (pos < length)
			{
				var s = textData.IndexOf("/*", StringComparison.Ordinal);
				if(s < 0) break;
				var e = textData.IndexOf("*/", s, StringComparison.Ordinal) + 2;
				textData = textData.Remove(s, e - s);
				pos = e;
			}

			pos = 0;
			length = textData.Length;
			while (pos < length)
			{
				var s = textData.IndexOf("//", StringComparison.Ordinal);
				if(s < 0) break;
				var e = textData.IndexOf('\n', s);
				textData = textData.Remove(s, e - s);
				pos = e;
			}

			var lengthBefore = -1;
			while (textData.Length != lengthBefore)
			{
				lengthBefore = textData.Length;
				textData = textData.Replace("\n\n", "\n");
			}

			_workingFolder = workingFolder;
			_textData = textData;
			_processedFiles = processedFiles;
			_textDataLength = _textData.Length;
		}

		private static DtsProcessor Process(string workingFolder, string fileName, Node parent, List<string> processedFiles)
		{
			try
			{
				return new DtsProcessor(workingFolder, File.ReadAllText(Path.Combine(workingFolder, fileName)), parent, processedFiles);
			}
			catch
			{
				//
			}
			return null;
		}

		public static string Dump(string workingFolder, string[] fileNames, List<string> processedFiles)
		{
			DtsProcessor processor = null;
			Node rootNode = null;
			for (var i = 0; i < fileNames.Length; i++)
			{
				var fileName = fileNames[i];
				processor = ProcessFileExt(workingFolder, fileName, rootNode, processedFiles);
				rootNode = processor._rootNode;
			}

			return processor == null ? string.Empty : processor._rootNode.Root.Dump();
		}

		public static RootNode Dump(string workingFolder, string[] fileNames)
		{
			DtsProcessor processor = null;
			Node rootNode = null;
			for (var i = 0; i < fileNames.Length; i++)
			{
				var fileName = fileNames[i];
				processor = ProcessFileExt(workingFolder, fileName, rootNode, new List<string>());
				rootNode = processor._rootNode;
			}

			return processor?._rootNode.Root;
		}

		private static DtsProcessor ProcessFileExt(string workingFolder, string fileName, Node parent, List<string> processedFiles)
		{
			var blob = Process(workingFolder, fileName, parent, processedFiles);
			if (blob == null) return null;

			while (!blob.EndOfBlob)
			{
				var block = blob.NextBlock();
				if (block == null) return blob;
				switch (block.Type)
				{
					case BlockType.LineBreak:
						break;
					case BlockType.IncludeStatement:
						var fileToProcess = block.Content;
						processedFiles.Add(fileToProcess);
						ProcessFileExt(workingFolder, fileToProcess, blob._rootNode, processedFiles);
						break;
				}
			}

			return blob;
		}

		private bool EndOfBlob => _positionInText >= _textDataLength;

		private TextBlock NextBlock()
		{
			var ch = _textData[_positionInText];
			switch (ch)
			{
				case '\n':
					return SkipLineBreak();
				case '#':
					return TryFetchIncludeOrPreprocessor();
				case '/':
					return TryFetchRootNodeOrDirective();
				case '&':
					return TryFetchNodeReference();
				default:
					if (char.IsLetterOrDigit(ch))
					{
						return TryFetchRootNodeOrDirective();
					}
					return null;
			}
		}

		private TextBlock SkipLineBreak()
		{
			_positionInText++;
			return TextBlock.LineBreak;
		}

		private TextBlock TryFetchIncludeOrPreprocessor()
		{
			if (!TryFetchInclude(_textData, _positionInText, out var endPos, out var fetchedText)) return null;
			_positionInText = endPos;
			var path = fetchedText.Trim().Trim('"');
			return path.EndsWith(".h>") ? TextBlock.LineBreak : new TextBlock(path, BlockType.IncludeStatement);
		}
		
		private static bool TryFetchInclude(string text, int startPos, out int endPos, out string fetchedText)
		{
			if (!text.MoveTo(ref startPos, "include", MoveStrategy.ImmediateValue))
			{
				fetchedText = null;
				endPos = startPos;
				return false;
			}
			var pos = startPos;
			if (!text.MoveTo(ref pos, null, MoveStrategy.UntilNewline))
			{
				fetchedText = null;
				endPos = startPos;
				return false;
			}

			var fileName = text.Substring(startPos, pos - startPos);
			fetchedText = fileName;
			endPos = pos;
			return true;
		}

		private TextBlock TryFetchRootNodeOrDirective()
		{
			if (TryFetchDirective(_textData, _positionInText, out var endPos, out var fetchedText))
			{
				if (_textData[endPos] != ';')
				{
					return null;
				}
				_positionInText = endPos + 1;
				return new TextBlock(fetchedText.Trim(), BlockType.Directive);
			}

			if (!TryFetchNodeDefinition(_textData, _positionInText, out endPos, out fetchedText)) return null;
			_positionInText = endPos;
			return !TryParseNodeDefinition(fetchedText, _rootNode, out _, this) ? null : new TextBlock(fetchedText, BlockType.NodeDefinition);
		}
		
		private static bool TryFetchPropertyDefinition(string text, int startPos, out int endPos, out string fetchedText, Node parentNode, DtsProcessor dts, out bool itWasInclude)
		{
			itWasInclude = false;
			var pos = startPos;
			if (!text.MoveTo(ref pos, ";", MoveStrategy.AllAllowed))
			{
				if (!text.MoveTo(ref pos, "#include", MoveStrategy.AllAllowed))
				{
					fetchedText = null;
					endPos = startPos;
					return false;
				}

				pos -= "#include".Length;
				if (!TryFetchInclude(text, pos, out endPos, out fetchedText))
				{
					fetchedText = null;
					endPos = startPos;
					return false;
				}

				var path = fetchedText.Trim().Trim('"');
				dts._processedFiles.Add(path);
				ProcessFileExt(dts._workingFolder, path, parentNode, dts._processedFiles);
				itWasInclude = true;
			}

			var property = text.Substring(startPos, pos - startPos);
			var openBracketPos = property.IndexOf('{');
			if (openBracketPos < 0)
			{
				fetchedText = property;
				endPos = pos;
				return true;
			}

			pos = startPos + openBracketPos;
			while (text.MoveTo(ref pos, "};", MoveStrategy.AllAllowed))
			{
				var nodeDefinition = text.Substring(startPos, pos - startPos);

				var ob = nodeDefinition.Count('{');
				var oc = nodeDefinition.Count('}');
				if (ob != oc) continue;
				endPos = pos;
				fetchedText = nodeDefinition;
				return true;
			}

			fetchedText = null;
			endPos = startPos;
			return false;
		}

		private TextBlock TryFetchNodeReference()
		{
			if (!TryFetchNodeDefinition(_textData, _positionInText, out var endPos, out var fetchedText)) return null;
			_positionInText = endPos;
			if (!TryParseNodeDefinition(fetchedText, _rootNode, out _, this))
			{
				return null;
			}

			return new TextBlock(fetchedText, BlockType.NodeReference);
		}

		private static bool TryParseNodeDefinition(string text, Node parentNode, out Node newNode, DtsProcessor dts)
		{
			var pos = 0;
			if (!text.MoveTo(ref pos, "{", MoveStrategy.AllAllowed))
			{
				newNode = null;
				return false;
			}
			var nodeNameAndLabel = text.Substring(0, pos - 1);
			var parts = nodeNameAndLabel.Split(':');

			var nodeLabel = string.Empty;
			string nodeName;
			if (parts.Length == 1)
			{
				nodeName = parts[0].Trim();
			}
			else
			{
				nodeLabel = parts[0].Trim();
				nodeName = parts[1].Trim();
			}

			newNode = parentNode.AddChild(nodeName, nodeLabel);

			text = text.TrimEnd(';', '}');
			pos = text.IndexOf('{') + 1;
			text = text.Substring(pos);
			pos = 0;
			while (true)
			{
				if (!TryFetchPropertyDefinition(text, pos, out var endPos, out var fetchedText, newNode, dts, out var itWasInclude)) break;
				if (itWasInclude)
				{
					pos += endPos;
					continue;
				}

				var tmp = endPos;
				if (TryFetchNodeDefinition(fetchedText, 0, out endPos, out fetchedText))
				{
					if(!TryParseNodeDefinition(fetchedText, newNode, out var _, dts))
					{
						newNode = null;
						return false;
					}
					pos += endPos;
					continue;
				}

				var propertyNameAndValue = text.Substring(pos, tmp - pos).Trim().TrimEnd(';');
				parts = propertyNameAndValue.Split('=');
				var propName = parts[0].Trim();
				var propValue = string.Empty;
				if (parts.Length == 2)
				{
					propValue = parts[1].Trim();
				}
				newNode.AddProperty(new NodeProperty(propName, propValue));

				pos = tmp;
			}

			return true;
		}

		private static bool TryFetchNodeDefinition(string text, int startPos, out int endPos, out string fetchedText)
		{
			var pos = startPos;
			if(!text.MoveTo(ref pos, "{", MoveStrategy.UntilChar, ';'))
			{
				fetchedText = null;
				endPos = startPos;
				return false;
			}
			pos = startPos;
			while (text.MoveTo(ref pos, "};", MoveStrategy.AllAllowed))
			{
				var nodeDefinition = text.Substring(startPos, pos - startPos);

				var ob = nodeDefinition.Count('{');
				var oc = nodeDefinition.Count('}');
				if (ob != oc) continue;
				endPos = pos;
				fetchedText = nodeDefinition;
				return true;
			}
			fetchedText = null;
			endPos = startPos;
			return false;
		}

		private static bool TryFetchDirective(string text, int startPos, out int endPos, out string fetchedText)
		{
			var pos = startPos;
			if (text.MoveTo(ref pos, "/", MoveStrategy.AllButWhitespacesAllowed))
			{
				var directive = text.Substring(startPos, pos - startPos);
				endPos = pos;
				fetchedText = directive;
				return true;
			}
			fetchedText = null;
			endPos = startPos;
			return false;
		}

		public override string ToString()
		{
			return _textData.Substring(_positionInText);
		}
	}
}