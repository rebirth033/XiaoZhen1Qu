namespace TianWen.Utility.Compiler
{
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using TianWen.Logger;
    using TianWen.Utility;

    public static class ResolveExpression
    {
        [CompilerGenerated]
        private static System.Func<string, int> func_0;
        private static NameValueCollection nameValueCollection_0;
        private const string string_0 = @"(:|\$\{)(?<name>_?[\w\.\u4e00-\u9fa5]*)([^\w.]|\})";
        private static string string_1 = "function aa(xx, yy){ return xx+ yy +1;}   aa(:_xx.中, ${_中.xx}); aa( ${_中.xx}, :_xx.中);";

        static ResolveExpression()
        {
            NameValueCollection values = new NameValueCollection();
            values.Add("_xx.中", "'aaa'");
            values.Add("_中.xx", "123");
            nameValueCollection_0 = values;
        }

        public static NameValueCollection AnalyzeSql(string expression, NameValueCollection paramCollection, string pattern = null)
        {
            Class15 class2 = new Class15 {
                nameValueCollection_0 = new NameValueCollection()
            };
            expression.smethod_1(paramCollection, new System.Action<string, string>(class2.method_0), pattern);
            return class2.nameValueCollection_0;
        }

        public static NameValueCollection AnalyzeSql(ref string expression, NameValueCollection paramCollection, string pattern = null)
        {
            return AnalyzeSql((string) expression, paramCollection, pattern).smethod_0(ref expression);
        }

        public static string Resolve(string expression, NameValueCollection paramCollection, string pattern = null)
        {
            Class16 class2 = new Class16 {
                string_0 = expression
            };
            expression.smethod_1(paramCollection, new System.Action<string, string>(class2.method_0), null);
            LoggerManager.Debug(string.Format("解析前表达式: {0}, 解析后表达式: {1}, 解析正则为: {2}", expression, class2.string_0, pattern));
            return class2.string_0;
        }

        private static NameValueCollection smethod_0(this NameValueCollection nameValueCollection_1, ref string string_2)
        {
            int num2 = 0;
            NameValueCollection values = new NameValueCollection();
            if (func_0 == null)
            {
                func_0 = new System.Func<string, int>(ResolveExpression.smethod_4);
            }
            foreach (string str in Enumerable.OrderByDescending<string, int>(nameValueCollection_1.AllKeys, func_0).ToArray<string>())
            {
                string str2 = string.Format("sqlCmdParas_{0}", num2++);
                values[str2] = nameValueCollection_1[str];
                string_2 = string_2.Replace(string.Format("':{0}'", str), string.Format(":{0}", str2));
                string_2 = string_2.Replace(string.Format(":{0}", str), string.Format(":{0}", str2));
            }
            return values;
        }

        internal static void smethod_1(this string string_2, NameValueCollection nameValueCollection_1, System.Action<string, string> action_0, string string_3 = null)
        {
            if (string.IsNullOrEmpty(string_3))
            {
                string_3 = AppSettingCache.Get<string>("ExpressionResolveRegex", @"(:|\$\{)(?<name>[a-z0-9A-Z_\.\u4e00-\u9fa5]+)([}]?)");
            }
            if (!string_3.Contains("?<name>"))
            {
                throw new FormatException("表达式解析正则不符合要求，至少应包括组名为name的描述:" + string_3);
            }
            string input = string_2;
            foreach (Match match in Regex.Matches(input, string_3, RegexOptions.IgnoreCase))
            {
                string str = match.Groups["name"].Value;
                if (nameValueCollection_1.AllKeys.Contains<string>(str, StringComparer.CurrentCultureIgnoreCase))
                {
                    action_0(match.Value, nameValueCollection_1[str]);
                }
            }
        }

        private static void smethod_2()
        {
            Resolve(string_1, nameValueCollection_0, @"(:|\$\{)(?<name>_?[\w\.\u4e00-\u9fa5]*)([^\w.]|\})");
        }

        private static void smethod_3()
        {
            string expression = "select t.*, :aa as bb, kk from dual where :bb = :cc";
            NameValueCollection paramCollection = new NameValueCollection();
            paramCollection.Add("aa", "1");
            paramCollection.Add("bb", "c");
            paramCollection.Add("dd", "111");
            Console.WriteLine(AnalyzeSql(ref expression, paramCollection, @"(:|\$\{)(?<name>_?[\w\.\u4e00-\u9fa5]*)([^\w.]|\})").Count == 2);
        }

        [CompilerGenerated]
        private static int smethod_4(string string_2)
        {
            return string_2.Length;
        }

        public static string ToJson(this NameValueCollection nameValueCollection_1)
        {
            StringBuilder builder = new StringBuilder("{");
            foreach (string str3 in nameValueCollection_1.Keys)
            {
                builder.AppendFormat("\"{0}\":\"{1}\",", str3, nameValueCollection_1[str3]);
            }
            string str = builder.ToString().TrimEnd(new char[] { ',' }) + "}";
            builder.Clear();
            return str;
        }

        [CompilerGenerated]
        private sealed class Class15
        {
            public NameValueCollection nameValueCollection_0;

            public void method_0(string string_0, string string_1)
            {
                this.nameValueCollection_0[string_0.TrimStart(new char[] { ':' })] = string_1;
            }
        }

        [CompilerGenerated]
        private sealed class Class16
        {
            public string string_0;

            public void method_0(string string_1, string string_2)
            {
                this.string_0 = this.string_0.Replace(string_1, string_2);
            }
        }
    }
}

