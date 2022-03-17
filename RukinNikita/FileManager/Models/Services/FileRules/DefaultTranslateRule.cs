﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager.Models.Services.FileRules
{
	public class DefaultTranslateRule : FileRule
	{
		public override int Priority { get; set; } = FileRuleConstants.MAX_PRIORITY;
		public override string Apply(string param)
		{
			Dictionary<string, string> table = GetTranslationTable();
			string res = "";
			for (int i = 0; i < param.Length; i++)
			{
				if (!table.TryGetValue(param[i].ToString(), out string value))
					value = "_";
				res += value;
			}
			return res;
		}

		protected virtual Dictionary<string, string> GetTranslationTable() => GetDefaultTable();

		protected virtual Dictionary<string, string> GetDefaultTable()
		{
			Dictionary<string, string> result = new Dictionary<string, string>
			{
				{ "а", "a"},
				{ "б", "b"},
				{ "в", "v"},
				{ "г", "g"},
				{ "д", "d"},
				{ "е", "e"},
				{ "ж", "gh"},
				{ "з", "z"},
				{ "и", "i"},
				{ "й", "y"},
				{ "к", "k"},
				{ "л", "l"},
				{ "м", "m"},
				{ "н", "n"},
				{ "о", "o"},
				{ "п", "p"},
				{ "р", "r"},
				{ "с", "c"},
				{ "т", "t"},
				{ "у", "u"},
				{ "ф", "f"},
				{ "х", "h"},
				{ "ц", "c"},
				{ "ч", "ch"},
				{ "ш", "sh"},
				{ "щ", "sh"},
				{ "ъ", "_"},
				{ "ы", "i"},
				{ "ь", "_"},
				{ "э", "e"},
				{ "ю", "yu"},
				{ "я", "ya"},
				{ "А", "A"},
				{ "Б", "B"},
				{ "В", "V"},
				{ "Г", "G"},
				{ "Д", "D"},
				{ "Е", "E"},
				{ "Ж", "Gh"},
				{ "З", "Z"},
				{ "И", "I"},
				{ "Й", "Y"},
				{ "К", "K"},
				{ "Л", "L"},
				{ "М", "M"},
				{ "Н", "N"},
				{ "О", "O"},
				{ "П", "P"},
				{ "Р", "R"},
				{ "С", "C"},
				{ "Т", "T"},
				{ "У", "U"},
				{ "Ф", "F"},
				{ "Х", "H"},
				{ "Ц", "C"},
				{ "Ч", "Ch"},
				{ "Ш", "Sh"},
				{ "Щ", "Sh"},
				{ "Ъ", "_"},
				{ "Ы", "I"},
				{ "Ь", "_"},
				{ "Э", "E"},
				{ "Ю", "Yu"},
				{ "Я", "Ya"},
				{ "ё", "e"},
				{ "Ё", "E"},
				{ "a", "a"},
				{ "b", "b"},
				{ "c", "c"},
				{ "d", "d"},
				{ "e", "e"},
				{ "f", "f"},
				{ "g", "g"},
				{ "h", "h"},
				{ "i", "i"},
				{ "j", "j"},
				{ "k", "k"},
				{ "l", "l"},
				{ "m", "m"},
				{ "n", "n"},
				{ "o", "o"},
				{ "p", "p"},
				{ "q", "q"},
				{ "r", "r"},
				{ "s", "s"},
				{ "t", "t"},
				{ "u", "u"},
				{ "v", "v"},
				{ "w", "w"},
				{ "x", "x"},
				{ "y", "y"},
				{ "z", "z"},
				{ "A", "A"},
				{ "B", "B"},
				{ "C", "C"},
				{ "D", "D"},
				{ "E", "E"},
				{ "F", "F"},
				{ "G", "G"},
				{ "H", "H"},
				{ "I", "I"},
				{ "J", "J"},
				{ "K", "K"},
				{ "L", "L"},
				{ "M", "M"},
				{ "N", "N"},
				{ "O", "O"},
				{ "P", "P"},
				{ "Q", "Q"},
				{ "R", "R"},
				{ "S", "S"},
				{ "T", "T"},
				{ "U", "U"},
				{ "V", "V"},
				{ "W", "W"},
				{ "X", "X"},
				{ "Y", "Y"},
				{ "Z", "Z"},
				{ "\\", "\\"},
			};
			return result;
		}
	}
}
