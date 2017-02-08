using System;

namespace CSharp.Helpers.Helpers
{
    public static class ConverterHelper
    {
        public static int? ToNullableInt32(this string s)
        {
            int i;
            if (Int32.TryParse(s, out i)) return i;
            return null;
        }
    }
}
