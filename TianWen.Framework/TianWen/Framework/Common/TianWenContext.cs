namespace TianWen.Framework.Common
{
    using System;
    using System.Collections.Specialized;
    using System.Runtime.CompilerServices;

    public class TianWenContext
    {
        public TianWenContext() : this(new NameValueCollection())
        {
        }

        public TianWenContext(NameValueCollection keyValues)
        {
            this.ContextCollection = keyValues;
        }

        public NameValueCollection ContextCollection { get; set; }

        public int Count
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ContextCollection["TopDataCount"]))
                {
                    return Convert.ToInt32(this.ContextCollection["TopDataCount"]);
                }
                return 0;
            }
            set
            {
                this.ContextCollection["TopDataCount"] = value.ToString();
            }
        }

        public int CurrentPageNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ContextCollection["CurrentPageNumber"]))
                {
                    return Convert.ToInt32(this.ContextCollection["CurrentPageNumber"]);
                }
                return 1;
            }
            set
            {
                this.ContextCollection["CurrentPageNumber"] = value.ToString();
            }
        }

        public string DeptId
        {
            get
            {
                return this.ContextCollection["DeptId"];
            }
            set
            {
                this.ContextCollection["DeptId"] = value.ToString();
            }
        }

        public string EventNo
        {
            get
            {
                return this.ContextCollection["EventNo"];
            }
            set
            {
                this.ContextCollection["EventNo"] = value;
            }
        }

        public string OrganId
        {
            get
            {
                return this.ContextCollection["OrganId"];
            }
            set
            {
                this.ContextCollection["OrganId"] = value.ToString();
            }
        }

        public int PageSize
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ContextCollection["PageSize"]))
                {
                    return Convert.ToInt32(this.ContextCollection["PageSize"]);
                }
                return 0;
            }
            set
            {
                this.ContextCollection["PageSize"] = value.ToString();
            }
        }

        public string RealName
        {
            get
            {
                return this.ContextCollection["RealName"].ToString();
            }
            set
            {
                this.ContextCollection["RealName"] = value;
            }
        }

        public string Theme
        {
            get
            {
                return this.ContextCollection["Theme"];
            }
            set
            {
                this.ContextCollection["Theme"] = value;
            }
        }

        public string TopActionId
        {
            get
            {
                return this.ContextCollection["TopActionId"];
            }
            set
            {
                this.ContextCollection["TopActionId"] = value;
            }
        }

        public string URL
        {
            get
            {
                return this.ContextCollection["URL"].ToString();
            }
            set
            {
                this.ContextCollection["URL"] = value;
            }
        }

        public string UserId
        {
            get
            {
                return this.ContextCollection["UserId"];
            }
            set
            {
                this.ContextCollection["UserId"] = value.ToString();
            }
        }

        public string UserID
        {
            get
            {
                return this.ContextCollection["UserId"];
            }
            set
            {
                this.ContextCollection["UserId"] = value;
            }
        }
    }
}

