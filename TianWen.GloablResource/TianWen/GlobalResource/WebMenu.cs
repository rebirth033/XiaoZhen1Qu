namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using TianWen.Exceptions;
    using TianWen.GlobalResource.Model;
    using TianWen.Persistence;

    public class WebMenu
    {
        private const string string_0 = "\r\nselect MENUID,\r\n       decode(substr(a.menuhref, 1, 4),\r\n              'http',\r\n              a.menuhref,\r\n              '',\r\n              '',\r\n              b.webroot || a.menuhref) MENUHREF,\r\n       MENUVALUE,\r\n       OWNERID,\r\n       a.REMARK,\r\n       MENUNAME,\r\n       TARGET,\r\n       \"RIGHT\",\r\n       ORDERBY,\r\n       HELPURL,\r\n       IMGURL, (select count(1) from webmenu c where c.ownerid = a.menuid) hasChild,\r\n       a.appcode,menuimg\r\n  from WebMenu a, APPLICATIONCONFIG b\r\n where a.appcode = b.appcode\r\n   and OWNERID = ?\r\n   and b.status = 'A'\r\n";
        private const string string_1 = "select MENUID,decode(substr(a.menuhref,1,4),'http', a.menuhref, '', '', b.webroot||a.menuhref) MENUHREF, MENUVALUE,OWNERID,a.REMARK,MENUNAME,TARGET,\"RIGHT\",ORDERBY,HELPURL,IMGURL,a.appcode,menuimg from WebMenu a,APPLICATIONCONFIG b where a.appcode = b.appcode and b.status='A'";
        private const string string_2 = "select HELPURL from WebMenu where MENUID=:MENUID";
        private const string string_3 = "select MENUNAME from WebMenu where MENUID=:MenuId";
        private const string string_4 = "select MENUVALUE from WebMenu where MENUID=:MenuId";
        private const string string_5 = "select MENUNAME from WebMenu a,APPLICATIONCONFIG b where a.appcode = b.appcode start with menuid = :MenuId connect by prior  ownerid = menuid ";

        public IList<WebmenuModel> GetAllUserMenus(string userRight, string parentId = "0", int level = 2)
        {
            DataView view = DbFactory.Instance.GetDbHelp("").GetDataView("select MENUID,decode(substr(a.menuhref,1,4),'http', a.menuhref, '', '', b.webroot||a.menuhref) MENUHREF, MENUVALUE,OWNERID,a.REMARK,MENUNAME,TARGET,\"RIGHT\",ORDERBY,HELPURL,IMGURL,a.appcode,menuimg from WebMenu a,APPLICATIONCONFIG b where a.appcode = b.appcode and b.status='A'", CommandType.Text, new IDataParameter[0]);
            view.Sort = "ORDERBY";
            return this.method_0(view, userRight, parentId, level);
        }

        public string GetHelpUrl(string string_6)
        {
            DataSet set = smethod_2(string_6);
            if (set.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(set.Tables[0].Rows[0][0]);
            }
            return string.Empty;
        }

        public string GetMenuName(string string_6)
        {
            Class1 class2 = new Class1 {
                string_0 = string_6
            };
            DataSet set = DbFactory.Instance.GetDbHelp("").GetDataSet("select MENUNAME from WebMenu where MENUID=:MenuId", new Func<IDbCommandHelp, IDataParameter[]>(class2.method_0), CommandType.Text);
            if (set.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(set.Tables[0].Rows[0][0]);
            }
            return string.Empty;
        }

        public DataSet GetMenuTitle(string string_6)
        {
            Class3 class2 = new Class3 {
                string_0 = string_6
            };
            return DbFactory.Instance.GetDbHelp("").GetDataSet("select MENUNAME from WebMenu a,APPLICATIONCONFIG b where a.appcode = b.appcode start with menuid = :MenuId connect by prior  ownerid = menuid ", new Func<IDbCommandHelp, IDataParameter[]>(class2.method_0), CommandType.Text);
        }

        public string GetMenuUrl(string string_6)
        {
            Class2 class2 = new Class2 {
                string_0 = string_6
            };
            DataSet set = DbFactory.Instance.GetDbHelp("").GetDataSet("select MENUVALUE from WebMenu where MENUID=:MenuId", new Func<IDbCommandHelp, IDataParameter[]>(class2.method_0), CommandType.Text);
            if (set.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(set.Tables[0].Rows[0][0]);
            }
            return string.Empty;
        }

        public DataSet GetUserMenu(string userRight)
        {
            DataView defaultView = smethod_2("0").Tables[0].DefaultView;
            defaultView.Sort = "ORDERBY";
            DataView view2 = DbFactory.Instance.GetDbHelp("").GetDataSet("select MENUID,decode(substr(a.menuhref,1,4),'http', a.menuhref, '', '', b.webroot||a.menuhref) MENUHREF, MENUVALUE,OWNERID,a.REMARK,MENUNAME,TARGET,\"RIGHT\",ORDERBY,HELPURL,IMGURL,a.appcode,menuimg from WebMenu a,APPLICATIONCONFIG b where a.appcode = b.appcode and b.status='A'", new IDataParameter[0]).Tables[0].DefaultView;
            view2.Sort = "ORDERBY";
            string str = "";
            for (int i = 0; i < defaultView.Count; i++)
            {
                if (this.method_1(defaultView[i]["RIGHT"].ToString(), defaultView[i]["MENUID"].ToString(), view2, userRight))
                {
                    str = str + "," + defaultView[i]["MENUID"].ToString();
                }
            }
            if (str != "")
            {
                defaultView.RowFilter = string.Format("{0} in ({1})", "MENUID", str.Substring(1));
            }
            else
            {
                defaultView.Table.Rows.Clear();
            }
            return defaultView.Table.DataSet;
        }

        public static DataView GetUserMenuByParentId(string parentId, string userRight)
        {
            DataView defaultView = smethod_2(parentId).Tables[0].DefaultView;
            defaultView.Sort = "ORDERBY";
            DataView view2 = DbFactory.Instance.GetDbHelp("").GetDataSet("select MENUID,decode(substr(a.menuhref,1,4),'http', a.menuhref, '', '', b.webroot||a.menuhref) MENUHREF, MENUVALUE,OWNERID,a.REMARK,MENUNAME,TARGET,\"RIGHT\",ORDERBY,HELPURL,IMGURL,a.appcode,menuimg from WebMenu a,APPLICATIONCONFIG b where a.appcode = b.appcode and b.status='A'", new IDataParameter[0]).Tables[0].DefaultView;
            view2.Sort = "ORDERBY";
            string str = "";
            for (int i = 0; i < defaultView.Count; i++)
            {
                if (smethod_0(defaultView[i]["RIGHT"].ToString(), defaultView[i]["MENUID"].ToString(), view2, userRight))
                {
                    str = str + "," + defaultView[i]["MENUID"].ToString();
                }
            }
            if (str != "")
            {
                defaultView.RowFilter = string.Format("{0} in ({1})", "MENUID", str.Substring(1));
                return defaultView;
            }
            defaultView.Table.Rows.Clear();
            return defaultView;
        }

        public DataSet GetUserMenuTwoLevel(string parentId, string userRight)
        {
            return GetUserMenuByParentId(parentId, userRight).Table.DataSet;
        }

        private IList<WebmenuModel> method_0(DataView dataView_0, string string_6, string string_7, int int_0)
        {
            List<WebmenuModel> list = new List<WebmenuModel>();
            if (int_0 >= 1)
            {
                foreach (DataRow row in dataView_0.Table.Select(string.Format("OWNERID='{0}'", string_7), "ORDERBY"))
                {
                    string str = row["MENUID"].ToString();
                    string str3 = row["RIGHT"].ToString();
                    if (this.method_1(str3, str, dataView_0, string_6))
                    {
                        string str2 = row["IMGURL"].ToString();
                        if (string.IsNullOrEmpty(str2))
                        {
                            str2 = row["menuimg"].ToString();
                        }
                        WebmenuModel item = new WebmenuModel {
                            Id = str,
                            Name = row["MenuName"].ToString(),
                            Href = row["MenuHref"].ToString(),
                            Target = row["Target"].ToString(),
                            ImgUrl = str2,
                            Remark = row["remark"].ToString(),
                            Childs = this.method_0(dataView_0, string_6, str, int_0 - 1)
                        };
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        private bool method_1(string string_6, string string_7, DataView dataView_0, string string_8)
        {
            DataView view;
            bool flag = false;
            if (!string.IsNullOrEmpty(string_6) && (flag = smethod_1(string_6, string_8)))
            {
                return true;
            }
            string str2 = string.Format("{0} = {1}", "OWNERID", string_7);
            DataView view2 = view = dataView_0.Table.Clone().DefaultView;
            view2.RowFilter = str2;
            for (int i = 0; i < view2.Count; i++)
            {
                string str = view2[i]["RIGHT"].ToString();
                if ((!string.IsNullOrEmpty(str) && (str != "N")) && (flag = smethod_1(str, string_8)))
                {
                    return true;
                }
                str2 = string.Format("{0} = {1}", "OWNERID", view2[i]["MENUID"].ToString());
                view.RowFilter = str2;
                for (int j = 0; j < view.Count; j++)
                {
                    str = view[j]["RIGHT"].ToString();
                    if ((!string.IsNullOrEmpty(str) && (str != "N")) && (flag = smethod_1(str, string_8)))
                    {
                        return true;
                    }
                }
            }
            return flag;
        }

        public static string ParseIntStr(string value)
        {
            Match match = new Regex(@"^\d*").Match(value);
            if (!match.Success)
            {
                return string.Empty;
            }
            return match.Value;
        }

        private static bool smethod_0(string string_6, string string_7, DataView dataView_0, string string_8)
        {
            string str = "";
            bool flag = false;
            if (string_6 == "")
            {
                string str2 = string.Format("{0} = {1}", "OWNERID", string_7);
                DataView view = dataView_0;
                view.RowFilter = str2;
                for (int i = 0; i < view.Count; i++)
                {
                    if (flag = smethod_1(view[i]["RIGHT"].ToString(), string_8))
                    {
                        return true;
                    }
                }
                return flag;
            }
            if ((string_6 == "N") || (string_6.Length >= 6))
            {
                return smethod_1(string_6, string_8);
            }
            if (string_6.Substring(0, 1) == "F")
            {
                str = "," + string_6 + ",";
                if (string_8.IndexOf(str) != -1)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private static bool smethod_1(string string_6, string string_7)
        {
            Func<string, bool> predicate = null;
            Class4 class2 = new Class4 {
                string_0 = string_7
            };
            if (string_6 == "N")
            {
                return true;
            }
            if (string.IsNullOrEmpty(string_6))
            {
                return false;
            }
            Class5 class3 = new Class5 {
                class4_0 = class2,
                string_0 = ParseIntStr(string_6)
            };
            if (string.IsNullOrEmpty(class3.string_0))
            {
                throw ExceptionManager.Instance.CreateException(new NullReferenceException("rightId"), "权限ID为空，menuRight值为:" + string_6);
            }
            if (predicate == null)
            {
                predicate = new Func<string, bool>(class2.method_0);
            }
            return string_6.Replace(class3.string_0, "").Select<char, string>(new Func<char, string>(class3.method_0)).Any<string>(predicate);
        }

        private static DataSet smethod_2(string ownerId)
        {
            Class6 class2 = new Class6 {
                string_0 = ownerId
            };
            return DbFactory.Instance.GetDbHelp("").GetDataSet("\r\nselect MENUID,\r\n       decode(substr(a.menuhref, 1, 4),\r\n              'http',\r\n              a.menuhref,\r\n              '',\r\n              '',\r\n              b.webroot || a.menuhref) MENUHREF,\r\n       MENUVALUE,\r\n       OWNERID,\r\n       a.REMARK,\r\n       MENUNAME,\r\n       TARGET,\r\n       \"RIGHT\",\r\n       ORDERBY,\r\n       HELPURL,\r\n       IMGURL, (select count(1) from webmenu c where c.ownerid = a.menuid) hasChild,\r\n       a.appcode,menuimg\r\n  from WebMenu a, APPLICATIONCONFIG b\r\n where a.appcode = b.appcode\r\n   and OWNERID = ?\r\n   and b.status = 'A'\r\n", new Func<IDbCommandHelp, IDataParameter[]>(class2.method_0), CommandType.Text);
        }

        [CompilerGenerated]
        private sealed class Class1
        {
            public string string_0;

            public IDataParameter[] method_0(IDbCommandHelp idbCommandHelp_0)
            {
                return new IDataParameter[] { idbCommandHelp_0.CreateParameter("MenuId", this.string_0) };
            }
        }

        [CompilerGenerated]
        private sealed class Class2
        {
            public string string_0;

            public IDataParameter[] method_0(IDbCommandHelp idbCommandHelp_0)
            {
                return new IDataParameter[] { idbCommandHelp_0.CreateParameter("MenuId", this.string_0) };
            }
        }

        [CompilerGenerated]
        private sealed class Class3
        {
            public string string_0;

            public IDataParameter[] method_0(IDbCommandHelp idbCommandHelp_0)
            {
                return new IDataParameter[] { idbCommandHelp_0.CreateParameter("MenuId", this.string_0) };
            }
        }

        [CompilerGenerated]
        private sealed class Class4
        {
            public string string_0;

            public bool method_0(string rightTem)
            {
                return (this.string_0.IndexOf(rightTem, StringComparison.Ordinal) != -1);
            }
        }

        [CompilerGenerated]
        private sealed class Class5
        {
            public WebMenu.Class4 class4_0;
            public string string_0;

            public string method_0(char char_0)
            {
                return string.Concat(new object[] { ",S", this.string_0, char_0, "," });
            }
        }

        [CompilerGenerated]
        private sealed class Class6
        {
            public string string_0;

            public IDataParameter[] method_0(IDbCommandHelp idbCommandHelp_0)
            {
                return new IDataParameter[] { idbCommandHelp_0.CreateParameter("OwnerId", this.string_0) };
            }
        }
    }
}

