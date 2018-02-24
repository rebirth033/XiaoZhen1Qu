namespace System
{
    using System.Runtime.CompilerServices;

    public static class StringEx
    {
        public static string GetEndWithABackSlash(this string input)
        {
            if (!string.IsNullOrEmpty(input) && !input.EndsWith(@"\"))
            {
                return (input + @"\");
            }
            return input;
        }

        public static string GetEndWithBackSlash(this string input)
        {
            if (!string.IsNullOrEmpty(input) && !input.EndsWith("/"))
            {
                return (input + "/");
            }
            return input;
        }

        public static string GetTruncationValue(this string orgianValue, int length)
        {
            if (string.IsNullOrEmpty(orgianValue))
            {
                return string.Empty;
            }
            return ((orgianValue.Length > length) ? (orgianValue.Substring(0, length - 1) + "...") : orgianValue);
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static string ReplaceSpecialChar(this string input)
        {
            input = input.Replace("//", "");
            input = input.Replace(@"\", "");
            input = input.Replace("\"", "");
            input = input.Replace("'", "");
            input = input.Replace("\n", "");
            return input;
        }
    }
}

