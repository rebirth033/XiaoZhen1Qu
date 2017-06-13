namespace TianWen.Persistence
{
    using System;
    using System.ComponentModel.Composition;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using TianWen.Exceptions;
    using TianWen.Plus4MEF;

    [PartCreationPolicy(CreationPolicy.NonShared), TianWenComponent("OleDbHelp")]
    public class DbHelp4Ole : BaseDbHelp
    {
        private IDbCommandHelp idbCommandHelp_0;

        public DbHelp4Ole()
        {
            base.DataSourceChangedHandle += new BaseDbHelp.DataSourceChange(this.method_5);
        }

        protected override void FillReturnValue(IDataParameter[] oldParams, IDataParameterCollection resultParam)
        {
            for (int i = 0; i < resultParam.Count; i++)
            {
                if (!((oldParams[i].Direction == ParameterDirection.Input) || (oldParams[i] is OleDbParameter)))
                {
                    oldParams[i].Value = ((DbParameter) resultParam[i]).Value;
                }
            }
        }

        public override string GetSeqNextValue(string seqName)
        {
            IDataParameter[] cmdParams = new OleDbParameter[3];
            cmdParams[0] = new OleDbParameter("Result", OleDbType.VarChar, 20);
            if (this.DataSourceInfo.SourceType == DataSourceTypes.ORACLE)
            {
                cmdParams[0].Direction = ParameterDirection.ReturnValue;
            }
            else
            {
                cmdParams[0].Direction = ParameterDirection.Output;
            }
            cmdParams[1] = new OleDbParameter("SeqName", seqName);
            cmdParams[2] = new OleDbParameter("SeqBaseCode", OleDbType.VarChar, 10);
            cmdParams[2].Value = "";
            try
            {
                this.ExecuteNonQuery("GetSeqNextVal", CommandType.StoredProcedure, cmdParams);
            }
            catch (Exception exception)
            {
                throw ExceptionManager.Instance.CreateException("0100200014", exception, new object[] { seqName, exception.Message });
            }
            return Convert.ToString(cmdParams[0].Value).Trim().Replace("\0", "");
        }

        private void method_5(DataSource dataSource_1)
        {
            base._Connection = new OleDbConnection(dataSource_1.ConnectionString);
            this.idbCommandHelp_0 = new CommandHelp4Ole(this, base._Connection, base._Transaction);
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

