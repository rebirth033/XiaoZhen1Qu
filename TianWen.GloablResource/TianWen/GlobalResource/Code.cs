namespace TianWen.GlobalResource
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using TianWen.Persistence;

    [Obsolete("该类已过期，请使用CodeCache来进行数据访问")]
    public class Code
    {
        private const string string_0 = "select TypeName,CodeName, CodeValue from Codes order by TypeName, CodeOrder";
        private const string string_1 = "select TypeName,CodeName, CodeValue from Codes where TypeName =:TypeName order by TypeName, CodeOrder";

        public DataSet GetAllCodes()
        {
            return DbFactory.Instance.GetDbHelp("").GetDataSet("select TypeName,CodeName, CodeValue from Codes order by TypeName, CodeOrder", new IDataParameter[0]);
        }

        public DataSet GetCodeList(string typeName)
        {
            Class7 class2 = new Class7 {
                string_0 = typeName
            };
            return DbFactory.Instance.GetDbHelp("").GetDataSet("select TypeName,CodeName, CodeValue from Codes where TypeName =:TypeName order by TypeName, CodeOrder", new Func<IDbCommandHelp, IDataParameter[]>(class2.method_0), CommandType.Text);
        }

        [CompilerGenerated]
        private sealed class Class7
        {
            public string string_0;

            public IDataParameter[] method_0(IDbCommandHelp idbCommandHelp_0)
            {
                return new IDataParameter[] { idbCommandHelp_0.CreateParameter("TypeName", this.string_0) };
            }
        }
    }
}

