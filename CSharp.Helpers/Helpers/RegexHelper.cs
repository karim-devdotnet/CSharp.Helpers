using System.Text.RegularExpressions;

namespace CSharp.Helpers.Helpers
{
    public class RegexHelper
    {
        public static string RemoveSpecialCharacters(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
        }
    }
}
