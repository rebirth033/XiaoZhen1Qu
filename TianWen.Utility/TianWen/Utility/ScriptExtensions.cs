namespace TianWen.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;

    public static class ScriptExtensions
    {
        [CompilerGenerated]
        private static System.Func<KeyValuePair<string, string>, string> func_0;
        private static IDictionary<string, string> idictionary_0 = new Dictionary<string, string>(20);

        public static void AppendJsLink2Header(this Page page_0, IDictionary<string, string> scriptList, string rootPath = "")
        {
            if (page_0.Header != null)
            {
                ClientScriptManager clientScript = page_0.ClientScript;
                string str = string.Empty;
                string key = string.Empty;
                int num2 = 0;
                foreach (KeyValuePair<string, string> pair in scriptList)
                {
                    str = smethod_2(pair.Value, rootPath);
                    key = smethod_1(str, pair.Key);
                    if (!(clientScript.IsClientScriptBlockRegistered(Regtype, key) || clientScript.IsClientScriptIncludeRegistered(Regtype, key)))
                    {
                        clientScript.RegisterClientScriptBlock(Regtype, key, "");
                        Control child = page_0.ParseControl(string.Format("<script type='text/javascript' src='{0}'></script>", str));
                        if (child != null)
                        {
                            page_0.Header.Controls.AddAt(num2++, child);
                        }
                    }
                }
            }
        }

        public static bool IncludeJs(this ClientScriptManager clientScriptManager, string string_0)
        {
            System.Func<KeyValuePair<string, string>, bool> func = null;
            Class17 class2 = new Class17 {
                string_0 = string_0
            };
            if (idictionary_0.Values.Contains(class2.string_0))
            {
                if (func == null)
                {
                    func = new System.Func<KeyValuePair<string, string>, bool>(class2.method_0);
                }
                if (func_0 == null)
                {
                    func_0 = new System.Func<KeyValuePair<string, string>, string>(ScriptExtensions.smethod_3);
                }
                IEnumerable<string> source = Enumerable.Select<KeyValuePair<string, string>, string>(Enumerable.Where<KeyValuePair<string, string>>(idictionary_0, func), func_0);
                if (source.Count<string>() == 1)
                {
                    clientScriptManager.IncludeJs(class2.string_0, source.First<string>(), "", false);
                }
                return true;
            }
            return false;
        }

        public static void IncludeJs(this ClientScriptManager clientScriptManager, IDictionary<string, string> loadInfos, string rootPath = "", bool forceAdd = false)
        {
            foreach (KeyValuePair<string, string> pair in loadInfos)
            {
                clientScriptManager.IncludeJs(pair.Key, pair.Value, rootPath, forceAdd);
            }
        }

        public static bool IncludeJs(this ClientScriptManager clientScriptManager, string string_0, string string_1, string rootPath, bool forceAdd = false)
        {
            string url = string_1;
            string_0 = smethod_1(string_1, string_0);
            url = smethod_2(string_1, rootPath);
            if (!((clientScriptManager.IsClientScriptBlockRegistered(Regtype, string_0) || clientScriptManager.IsClientScriptIncludeRegistered(Regtype, string_0)) ? !forceAdd : false))
            {
                clientScriptManager.RegisterClientScriptInclude(Regtype, string_0, url);
            }
            return true;
        }

        public static bool RegScript(this ClientScriptManager clientScriptManager, string string_0, string script, bool forceAdd = false)
        {
            if (string.IsNullOrEmpty(string_0))
            {
                string_0 = Guid.NewGuid().ToString();
            }
            bool addScriptTags = smethod_0(script);
            if (!(clientScriptManager.IsStartupScriptRegistered(Regtype, string_0) || forceAdd))
            {
                clientScriptManager.RegisterStartupScript(Regtype, string_0, script, addScriptTags);
            }
            return true;
        }

        private static bool smethod_0(string script)
        {
            return !Regex.IsMatch(script.Trim(), @"^\<\s*script.*[^/]\>", RegexOptions.IgnoreCase);
        }

        private static string smethod_1(string string_0, string string_1)
        {
            string_0 = string_0.ToLower();
            string_0 = string_0.Replace("//", "/");
            if (idictionary_0.ContainsKey(string_0))
            {
                if (string_1 != idictionary_0[string_0])
                {
                    string_1 = idictionary_0[string_0];
                }
                return string_1;
            }
            lock (idictionary_0)
            {
                if (idictionary_0.ContainsKey(string_0))
                {
                    return string_1;
                }
                string_1 = string_1 ?? Guid.NewGuid().ToString();
                idictionary_0.Add(string_0, string_1);
            }
            return string_1;
        }

        private static string smethod_2(string string_0, string string_1)
        {
            string virtualPath = string_0;
            if (virtualPath.StartsWith("@"))
            {
                virtualPath = HttpContext.Current.Request.ApplicationPath + "/jshtccss/" + virtualPath.Substring(1);
            }
            else if (!string.IsNullOrEmpty(string_1))
            {
                virtualPath = string_1 + "//" + virtualPath;
            }
            return HttpContext.Current.Response.ApplyAppPathModifier(virtualPath);
        }

        [CompilerGenerated]
        private static string smethod_3(KeyValuePair<string, string> keyValuePair_0)
        {
            return keyValuePair_0.Key;
        }

        public static void WriteJsLink(this ClientScriptManager clientScriptManager_0, HtmlTextWriter write, IDictionary<string, string> loadInfos, string rootPath = "", bool forceAdd = false)
        {
            foreach (KeyValuePair<string, string> pair in loadInfos)
            {
                clientScriptManager_0.WriteJsLink(write, pair.Value, pair.Key, rootPath, forceAdd);
            }
        }

        public static void WriteJsLink(this ClientScriptManager clientScriptManager_0, HtmlTextWriter write, string string_0, string string_1 = "", string rootPath = "", bool forceAdd = false)
        {
            string str = string_0;
            string_1 = smethod_1(string_0, string_1);
            if (!str.ToLower().StartsWith("http://"))
            {
                str = smethod_2(string_0, rootPath);
            }
            if (!(clientScriptManager_0.IsClientScriptBlockRegistered(Regtype, string_1) || clientScriptManager_0.IsClientScriptIncludeRegistered(Regtype, string_1)))
            {
                clientScriptManager_0.RegisterClientScriptBlock(Regtype, string_1, "");
                write.WriteLine("<script src='{0}' type='text/javascript'></script>", str);
            }
        }

        private static Type Regtype
        {
            get
            {
                return ((HttpContext.Current == null) ? typeof(ScriptExtensions) : ((Page) HttpContext.Current.CurrentHandler).GetType());
            }
        }

        [CompilerGenerated]
        private sealed class Class17
        {
            public string string_0;

            public bool method_0(KeyValuePair<string, string> keyValuePair_0)
            {
                return (keyValuePair_0.Value == this.string_0);
            }
        }
    }
}

