namespace TianWen.Persistence
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using TianWen.Exceptions;

    public static class CmdParameterExt
    {
        public static IDataParameter[] Convert2Parameters(this NameValueCollection postData, IDbCommandHelp idbCommandHelp_0)
        {
            postData.Remove("oper");
            postData.Remove("id");
            postData.Remove("tree_parent");
            IDataParameter[] parameterArray = idbCommandHelp_0.CreateParameters(postData.Count);
            for (int i = 0; i < postData.Count; i++)
            {
                parameterArray[i] = idbCommandHelp_0.CreateParameter(postData.Keys[i], postData[i]);
            }
            return parameterArray;
        }

        public static IDataParameter[] SetParameter(this IDataParameter[] paramList, string paramName, DbType type, ParameterDirection pDir, object value = null)
        {
            Class3 class2 = new Class3 {
                string_0 = paramName
            };
            IDataParameter parameter = Enumerable.FirstOrDefault<IDataParameter>(paramList, new System.Func<IDataParameter, bool>(class2.method_0));
            if (parameter == null)
            {
                throw new TianWenException("找不到指定的参数名", new ArgumentOutOfRangeException(class2.string_0));
            }
            parameter.DbType = type;
            parameter.Direction = pDir;
            if (value != null)
            {
                parameter.Value = value;
            }
            return paramList;
        }

        [CompilerGenerated]
        private sealed class Class3
        {
            public string string_0;

            public bool method_0(IDataParameter idataParameter_0)
            {
                return (idataParameter_0.ParameterName == this.string_0);
            }
        }
    }
}

