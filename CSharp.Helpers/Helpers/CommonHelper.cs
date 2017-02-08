using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharp.Helpers.Helpers
{
    public static class CommonHelper
    {
        public static string EncodeAndHighlightKeyWords(string text, string keywords,
            params string[] highlightBraces)
        {
            //Highlight
            if (text == String.Empty || keywords == String.Empty || highlightBraces == null
                || highlightBraces.Count() != 2)
                return text;
            var words = keywords.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return
                    words.Select(word => word.Trim()).Aggregate(text,
                             (current, pattern) =>
                             Regex.Replace(current,
                                             Regex.Escape(pattern),
                                               string.Format("§{0}?",
                                               "$0"),
                                               RegexOptions.IgnoreCase))
                                               .Replace("§", highlightBraces[0])
                                               .Replace("?", highlightBraces[1]);
        }

        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            s = s.ToLower();
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        
        public static string RemoveSpecialCharacters(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
        }
    }
}
