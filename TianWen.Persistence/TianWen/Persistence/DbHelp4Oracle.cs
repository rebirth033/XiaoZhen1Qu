namespace TianWen.Persistence
{
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.ComponentModel.Composition;
    using System.Data;
    using System.Data.Common;
    using TianWen.Exceptions;
    using TianWen.Plus4MEF;

    [TianWenComponent("OracleDbHelp"), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DbHelp4Oracle : BaseDbHelp
    {
        private IDbCommandHelp idbCommandHelp_0;

        public DbHelp4Oracle()
        {
            base.DataSourceChangedHandle += new BaseDbHelp.DataSourceChange(this.method_5);
        }

        protected override void FillReturnValue(IDataParameter[] oldParams, IDataParameterCollection resultParam)
        {
            for (int i = 0; i < resultParam.Count; i++)
            {
                if (!((oldParams[i].Direction == ParameterDirection.Input) || (oldParams[i] is OracleParameter)))
                {
                    oldParams[i].Value = ((DbParameter) resultParam[i]).Value;
                }
            }
        }

        public override string GetSeqNextValue(string seqName)
        {
            IDataParameter[] cmdParams = new OracleParameter[3];
            cmdParams[0] = new OracleParameter("Result", OracleDbType.Varchar2, 20);
            cmdParams[0].Direction = ParameterDirection.ReturnValue;
            cmdParams[1] = new OracleParameter("SeqName", seqName);
            cmdParams[2] = new OracleParameter("SeqBaseCode", OracleDbType.Varchar2, 10);
            cmdParams[2].Value = "";
            try
            {
                this.ExecuteNonQuery("GetSeqNextVal", CommandType.StoredProcedure, cmdParams);
            }
            catch (Exception exception)
            {
                throw ExceptionManager.Instance.CreateException("0100200027", exception, new object[] { seqName, exception.Message });
            }
            return Convert.ToString(cmdParams[0].Value).Trim().Replace("\0", "");
        }

        private void method_5(DataSource dataSource_1)
        {
            base._Connection = new OracleConnection(dataSource_1.ConnectionString);
            this.idbCommandHelp_0 = new CommandHelp4Oracle(this, base._Connection, base._Transaction);
        }

        public override IDbCommandHelp CommandHelp
        {
            get
            {
                return this.idbCommandHelp_0;
            }
        }
    }
}

