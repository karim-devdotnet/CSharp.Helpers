using System;
using System.Text.RegularExpressions;

namespace CSharp.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static bool CompareTo(this string str, string secondString, bool IgnoreCaseSensitive)
        {
            if (string.IsNullOrEmpty(str) && string.IsNullOrEmpty(secondString))
                return true;
            else if (!string.IsNullOrEmpty(str) && string.IsNullOrEmpty(secondString)
                || string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(secondString))
                return false;
            else
            {
                if (IgnoreCaseSensitive)
                {
                    return str.ToLower() == secondString.ToLower();
                }
                else
                    return str == secondString;
            }
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            return Regex.Replace(str, "[^0-9a-zA-Z]+", "", RegexOptions.Compiled);
        }

        public static string SubstringExtended(this string str, int startIndex, int length )
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            if (str.Length < length)
                return str;

            return str.Substring(startIndex,length);
        }

        public static string ToLowerExtended(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            return str.ToLower();
        }
    }

}
