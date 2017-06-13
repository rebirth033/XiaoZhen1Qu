namespace TianWen.Persistence
{
    using System;
    using System.Data;

    public class SqlBuilder
    {
        public const string ORIGINAL_PARAM_PRE = "Original_";

        private SqlBuilder()
        {
        }

        public static string CreateDeleteSql(string sourceTableName, string where)
        {
            return string.Format("delete from {0} {1}", sourceTableName, where);
        }

        public static string CreateInsertSql(string sourceTableName, string[] sourceColumns, string sqlParamPre)
        {
            string[] sqlParamName = GetSqlParamName(sourceColumns, sqlParamPre);
            return string.Format("insert into {0}({1}) values({2}) ", sourceTableName, string.Join(", ", sourceColumns), string.Join(", ", sqlParamName));
        }

        public static string CreateSelectSql(string sourceTableName, string[] sourceColumns, string where)
        {
            return string.Format("select {0} from {1} {2} ", string.Join(", ", sourceColumns), sourceTableName, where);
        }

        public static string CreateUpdateSql(string sourceTableName, string[] sourceColumns, string where, string sqlParamPre)
        {
            string[] sqlParamName = GetSqlParamName(sourceColumns, sqlParamPre);
            string[] strArray2 = new string[sourceColumns.Length];
            for (int i = 0; i < sourceColumns.Length; i++)
            {
                strArray2[i] = sourceColumns[i] + " = " + sqlParamName[i];
            }
            return string.Format("update {0} set {1} {2} ", sourceTableName, string.Join(", ", strArray2), where);
        }

        public static string CreateWhereClause(IDataParameter[] whereParams, string sqlParamPre)
        {
            string[] strArray = new string[whereParams.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                if (whereParams[i].SourceVersion == DataRowVersion.Original)
                {
                    strArray[i] = whereParams[i].ParameterName.Substring("Original_".Length) + " = " + GetSqlParamName(whereParams[i].ParameterName, sqlParamPre);
                }
                else
                {
                    strArray[i] = whereParams[i].ParameterName + " = " + GetSqlParamName(whereParams[i].ParameterName, sqlParamPre);
                }
            }
            return string.Format("where {0} ", string.Join(" and ", strArray));
        }

        public static string GetFormatedSql(IDbCommand idbCommand_0, string sqlParamPre)
        {
            if (idbCommand_0 == null)
            {
                return string.Empty;
            }
            string commandText = idbCommand_0.CommandText;
            try
            {
                int num2;
                string[] strArray;
                if ((idbCommand_0.Parameters == null) || (idbCommand_0.Parameters.Count == 0))
                {
                    return commandText;
                }
                if (idbCommand_0.CommandType == CommandType.Text)
                {
                    strArray = commandText.Split(sqlParamPre.ToCharArray());
                    if (sqlParamPre == "?")
                    {
                        for (num2 = 0; num2 < idbCommand_0.Parameters.Count; num2++)
                        {
                            strArray[num2 + 1] = string.Format("{0}{1}", smethod_0((IDataParameter) idbCommand_0.Parameters[num2]), strArray[num2 + 1]);
                        }
                        commandText = string.Join("", strArray);
                    }
                    else
                    {
                        commandText = commandText + " ";
                        foreach (IDataParameter parameter in idbCommand_0.Parameters)
                        {
                            commandText = commandText.Replace(sqlParamPre + parameter.ParameterName + " ", smethod_0(parameter));
                            commandText = commandText.Replace(sqlParamPre + parameter.ParameterName + ")", smethod_0(parameter) + ")");
                            commandText = commandText.Replace(sqlParamPre + parameter.ParameterName + "'", smethod_0(parameter) + "'");
                            commandText = commandText.Replace(sqlParamPre + parameter.ParameterName + ",", smethod_0(parameter) + ",");
                        }
                    }
                    int index = commandText.IndexOf(" where ");
                    if (index > 0)
                    {
                        commandText = commandText.Substring(0, index) + commandText.Substring(index).Replace("= ''", " is null ");
                    }
                    return commandText;
                }
                strArray = new string[idbCommand_0.Parameters.Count];
                for (num2 = 0; num2 < idbCommand_0.Parameters.Count; num2++)
                {
                    strArray[num2] = string.Format("'{0}'", Convert.ToString(((IDataParameter) idbCommand_0.Parameters[num2]).Value));
                }
                if (((IDataParameter) idbCommand_0.Parameters[0]).Direction == ParameterDirection.ReturnValue)
                {
                    commandText = string.Format("{0}={1}({2})", strArray[0], commandText, string.Join(",", strArray, 1, strArray.Length - 1));
                }
                else
                {
                    commandText = string.Format("{0}({1})", commandText, string.Join(",", strArray));
                }
            }
            catch
            {
            }
            return commandText;
        }

        public static string[] GetSqlParamName(string[] sourceColumns, string sqlParamPre)
        {
            int num2;
            string[] strArray = new string[sourceColumns.Length];
            if (sqlParamPre == "?")
            {
                for (num2 = 0; num2 < sourceColumns.Length; num2++)
                {
                    strArray[num2] = "?";
                }
                return strArray;
            }
            for (num2 = 0; num2 < sourceColumns.Length; num2++)
            {
                strArray[num2] = sqlParamPre + sourceColumns[num2];
            }
            return strArray;
        }

        public static string GetSqlParamName(string paramName, string sqlParamPre)
        {
            if (sqlParamPre == "?")
            {
                return sqlParamPre;
            }
            return (sqlParamPre + paramName);
        }

        public static string GetTableNameFromSQL(string string_0)
        {
            int index = string_0.ToUpper().IndexOf(" FROM ");
            string str = string_0.Substring(index + 6);
            index = str.IndexOf(" ");
            if (index >= 0)
            {
                str = str.Substring(0, index);
            }
            else
            {
                index = str.IndexOf(",");
                if (index >= 0)
                {
                    str = str.Substring(0, index);
                }
            }
            str = str.Trim();
            if (string.IsNullOrEmpty(str) || str.StartsWith("("))
            {
                str = "Table";
            }
            return str;
        }

        private static string smethod_0(IDataParameter idataParameter_0)
        {
            if (idataParameter_0.DbType != DbType.DateTime)
            {
                return string.Format("'{0}'", Convert.ToString(idataParameter_0.Value));
            }
            return string.Format("to_date('{0}', 'yyyy-mm-dd HH24:MI:SS')", Convert.ToString(idataParameter_0.Value));
        }
    }
}

