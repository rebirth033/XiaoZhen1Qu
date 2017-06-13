namespace TianWen.Framework.Common
{
    using System;
    using System.Text;

    public class StringHelper
    {
        public static string ArrayToString(string[] array)
        {
            return ArrayToString(array, ",");
        }

        public static string ArrayToString(string[] array, string split)
        {
            if (array.Length == 0)
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                builder.Append(array[i]);
                builder.Append(split);
            }
            string str = builder.ToString();
            return str.Substring(0, str.Length - 1);
        }
    }
}

