namespace TianWen.GlobalResource
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using TianWen.Persistence;

    public class FlowWork
    {
        private const string string_0 = "select type,ownerId,name,value,ORDINAL from FLOWWORKCONFIG where type=:Type order by ORDINAL";

        public string GetShowTypeHTML(int int_0, string goUrl, string showName, int flowTypeCount, string intWaitCount)
        {
            if (int_0 == 0)
            {
                return string.Concat(new object[] { "<table cellSpacing='0' cellPadding='0' id=tab", int_0, "><tr><td><img src='../images/FlowWork/blue_a.gif'></img></td><td background='../images/FlowWork/blue_c.gif'><a href='#' onclick=\"Javascript:ChangeType('", goUrl, "',", int_0, ",", flowTypeCount, ")\">", showName, intWaitCount, "</a></td><td><img src='../images/FlowWork/blue_b.gif'></img></td></tr></table>" });
            }
            return string.Concat(new object[] { "<table cellSpacing='0' cellPadding='0' id=tab", int_0, "><tr><td><img src='../images/FlowWork/white_a.gif'></img></td><td background='../images/FlowWork/white_c.gif'><a href='#' onclick=\"Javascript:ChangeType('", goUrl, "',", int_0, ",", flowTypeCount, ")\">", showName, intWaitCount, "</a></td><td><img src='../images/FlowWork/white_b.gif'></img></td></tr></table>" });
        }

        public DataSet GetWorkUrlByType(string type)
        {
            Class0 class2 = new Class0 {
                string_0 = type
            };
            return DbFactory.Instance.GetDbHelp("").GetDataSet("select type,ownerId,name,value,ORDINAL from FLOWWORKCONFIG where type=:Type order by ORDINAL", new Func<IDbCommandHelp, IDataParameter[]>(class2.method_0), CommandType.Text);
        }

        [CompilerGenerated]
        private sealed class Class0
        {
            public string string_0;

            public IDataParameter[] method_0(IDbCommandHelp idbCommandHelp_0)
            {
                return new IDataParameter[] { idbCommandHelp_0.CreateParameter("Type", this.string_0) };
            }
        }
    }
}

