using NHibernate;
using System;
using System.Collections.Generic;
using System.Web;
using TianWen.Nhibernate.Repository;
using TianWen.Nhibernate.Threading;

namespace TianWen.Nhibernate
{
    public class SessionModule : IHttpModule
    {
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsolutePath.ToLower();
            if (!this.UrlIgnored(url))
            {
                foreach (KeyValuePair<string, ISessionFactory> pair in DbFactory.Instance.mfp.SessionFactorys)
                {
                    string name = "NHSession" + pair.Key;
                    string str3 = "NHStatelessSession" + pair.Key;
                    LogicalThreadContext.SetData(name, pair.Value.OpenSession());
                }
            }
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsolutePath.ToLower();
            if (!this.UrlIgnored(url))
            {
                foreach (KeyValuePair<string, ISessionFactory> pair in DbFactory.Instance.mfp.SessionFactorys)
                {
                    ISession data = (ISession) LogicalThreadContext.GetData("NHSession" + pair.Key);
                    if ((data != null) && data.IsOpen)
                    {
                        data.Close();
                    }
                }
            }
        }

        private bool CheckExt(string url)
        {
            if (Config.NhExts != "")
            {
                string str = "";
                if (Config.NhExts.StartsWith(","))
                {
                    str = Config.NhExts.Substring(1);
                }
                if (str.EndsWith(","))
                {
                    str = str.Substring(0, str.Length - 1);
                }
                string[] strArray = str.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (url.EndsWith(strArray[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.Application_BeginRequest);
            context.EndRequest += new EventHandler(this.Application_EndRequest);
        }

        private bool UrlIgnored(string url)
        {
            if (url.IndexOf(".", StringComparison.Ordinal) < 0)
            {
                return false;
            }
            if ((Config.NhExts != "") && this.CheckExt(url))
            {
                return false;
            }
            if (((url.EndsWith("aspx") || url.EndsWith("ashx")) || (url.EndsWith("asmx") || url.EndsWith("axd"))) || url.EndsWith("svc"))
            {
                return false;
            }
            if ((url.IndexOf(".aspx/") >= 0) || (url.IndexOf(".asmx/") >= 0))
            {
                return false;
            }
            return true;
        }
    }
}

