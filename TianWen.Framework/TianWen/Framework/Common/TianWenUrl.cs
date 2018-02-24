namespace TianWen.Framework.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TianWenUrl
    {
        private string _AbsoluteUrl = "";
        private string _NoneParamsUrl = "";
        private Dictionary<string, UrlParam> _Params = new Dictionary<string, UrlParam>();
        private string _Query = "";

        public TianWenUrl(string url)
        {
            this.Init(url);
        }

        public void AddOrUpdateParam(UrlParam param)
        {
            if (this._Params.ContainsKey(param.Name))
            {
                this._Params[param.Name] = param;
            }
            else
            {
                this._Params.Add(param.Name, param);
            }
        }

        public void AddOrUpdateParam(string name, string value)
        {
            UrlParam param = new UrlParam {
                Name = name,
                Value = value
            };
            this.AddOrUpdateParam(param);
        }

        public void Clear()
        {
            this._Params.Clear();
        }

        private string CreateParamStr()
        {
            StringBuilder builder = new StringBuilder();
            foreach (UrlParam param in this._Params.Values)
            {
                builder.Append(param.Name + "=" + param.Value);
                builder.Append("&");
            }
            string str = builder.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                return str.Substring(0, str.Length - 1);
            }
            return null;
        }

        public string GetUrl()
        {
            if (string.IsNullOrEmpty(this._AbsoluteUrl))
            {
                return string.Empty;
            }
            string str = this.CreateParamStr();
            return (!string.IsNullOrEmpty(str) ? (this._NoneParamsUrl + "?" + str) : this._NoneParamsUrl);
        }

        private void Init(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                this._AbsoluteUrl = url;
                if ((this._AbsoluteUrl.IndexOf('?') > 0) && (this._AbsoluteUrl.Split(new char[] { '?' }).Length == 2))
                {
                    this._NoneParamsUrl = this._AbsoluteUrl.Split(new char[] { '?' })[0];
                    string str = this._AbsoluteUrl.Split(new char[] { '?' })[1];
                    foreach (string str2 in str.Split(new char[] { '&' }))
                    {
                        string[] strArray2 = str2.Split(new char[] { '=' });
                        if ((strArray2 != null) && (strArray2.Length == 2))
                        {
                            UrlParam param = new UrlParam {
                                Name = strArray2[0],
                                Value = strArray2[1]
                            };
                            if (this._Params.ContainsKey(param.Name))
                            {
                                this._Params[param.Name].Value = this._Params[param.Name].Value + "," + param.Value;
                            }
                            else
                            {
                                this._Params.Add(param.Name, param);
                            }
                        }
                    }
                }
                else
                {
                    this._NoneParamsUrl = url;
                }
            }
        }

        public void RemoveParam(string name)
        {
            if (this._Params.ContainsKey(name))
            {
                this._Params.Remove(name);
            }
        }

        public IList<UrlParam> Params
        {
            get
            {
                return this._Params.Values.ToList<UrlParam>();
            }
        }
    }
}

