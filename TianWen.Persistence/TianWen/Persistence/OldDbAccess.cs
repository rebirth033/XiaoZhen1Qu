namespace TianWen.Persistence
{
    using System;
    using System.ComponentModel.Composition;
    using System.Data;
    using System.Data.Common;
    using TianWen.Exceptions;
    using TianWen.Logger;
    using TianWen.Plus4MEF;

    [TianWenComponent("DbAccess"), PartCreationPolicy(CreationPolicy.NonShared)]
    public class OldDbAccess : IDbAccessSave
    {
        private IDbAccessSave idbAccessSave_0;
        private IDbCommandHelp idbCommandHelp_0;
        private IDbHelp idbHelp_0;

        public OldDbAccess() : this(null)
        {
        }

        public OldDbAccess(string dataSourceName) : this(dataSourceName, null)
        {
        }

        public OldDbAccess(string dataSourceName, IDbAccessSave saveInstance)
        {
            this.Init(dataSourceName, saveInstance);
        }

        public void Init(string dataSourceName, IDbAccessSave component)
        {
            if (string.IsNullOrEmpty(dataSourceName))
            {
                this.idbHelp_0 = DbFactory.Instance.GetDbHelp("");
            }
            else
            {
                this.idbHelp_0 = DbFactory.Instance.GetDbHelp(dataSourceName);
            }
            this.idbCommandHelp_0 = this.idbHelp_0.CommandHelp;
            this.idbAccessSave_0 = component ?? this;
        }

        private int method_0(DbDataAdapter dbDataAdapter_0, DataTable dataTable_0)
        {
            int num2;
            try
            {
                num2 = dbDataAdapter_0.Update(dataTable_0);
            }
            catch (Exception exception)
            {
                DataRow[] errors = dataTable_0.GetErrors();
                DataRow row = null;
                IDbCommand updateCommand = null;
                if (errors.Length > 0)
                {
                    row = errors[0];
                    if (errors[0].RowState == DataRowState.Modified)
                    {
                        updateCommand = ((IDbDataAdapter) dbDataAdapter_0).UpdateCommand;
                        row = dataTable_0.Select(null, null, DataViewRowState.ModifiedOriginal)[0];
                    }
                    else if (errors[0].RowState == DataRowState.Added)
                    {
                        updateCommand = ((IDbDataAdapter) dbDataAdapter_0).InsertCommand;
                    }
                    else if (errors[0].RowState == DataRowState.Deleted)
                    {
                        updateCommand = ((IDbDataAdapter) dbDataAdapter_0).DeleteCommand;
                    }
                }
                if (updateCommand != null)
                {
                    foreach (IDataParameter parameter in updateCommand.Parameters)
                    {
                        parameter.Value = row[parameter.SourceColumn];
                    }
                    errors[0].ClearErrors();
                    throw ExceptionManager.Instance.CreateException("0100200001", exception, new object[] { SqlBuilder.GetFormatedSql(updateCommand, this.idbCommandHelp_0.SqlParamPrefix) });
                }
                throw ExceptionManager.Instance.CreateException("0100200002", exception, new object[] { dataTable_0.TableName });
            }
            return num2;
        }

        private int method_1(DataTable dataTable_0)
        {
            using (DbDataAdapter adapter = this.idbCommandHelp_0.CreateDbDataAdapter(null))
            {
                ((IDbDataAdapter) adapter).DeleteCommand = this.method_6(dataTable_0);
                return this.method_0(adapter, dataTable_0);
            }
        }

        private int method_2(DataTable dataTable_0)
        {
            using (DbDataAdapter adapter = this.idbCommandHelp_0.CreateDbDataAdapter(null))
            {
                ((IDbDataAdapter) adapter).UpdateCommand = this.method_4(dataTable_0);
                return this.method_0(adapter, dataTable_0);
            }
        }

        private int method_3(DataTable dataTable_0)
        {
            using (DbDataAdapter adapter = this.idbCommandHelp_0.CreateDbDataAdapter(null))
            {
                ((IDbDataAdapter) adapter).UpdateCommand = this.method_4(dataTable_0);
                ((IDbDataAdapter) adapter).InsertCommand = this.method_5(dataTable_0);
                return this.method_0(adapter, dataTable_0);
            }
        }

        private IDbCommand method_4(DataTable dataTable_0)
        {
            IDataParameter[] cmdParams = this.method_7(dataTable_0);
            IDataParameter[] whereParams = this.method_8(dataTable_0);
            return this.idbCommandHelp_0.CreateUpdateCommand(dataTable_0.TableName, whereParams, cmdParams);
        }

        private IDbCommand method_5(DataTable dataTable_0)
        {
            IDataParameter[] cmdParams = this.method_7(dataTable_0);
            return this.idbCommandHelp_0.CreateInsertCommand(dataTable_0.TableName, cmdParams);
        }

        private IDbCommand method_6(DataTable dataTable_0)
        {
            IDataParameter[] whereParams = this.method_8(dataTable_0);
            return this.idbCommandHelp_0.CreateDeleteCommand(dataTable_0.TableName, whereParams);
        }

        private IDataParameter[] method_7(DataTable dataTable_0)
        {
            IDataParameter[] parameterArray = this.idbCommandHelp_0.CreateParameters(dataTable_0.Columns.Count);
            for (int i = 0; i < parameterArray.Length; i++)
            {
                parameterArray[i] = this.method_9(dataTable_0.Columns[i]);
            }
            return parameterArray;
        }

        private IDataParameter[] method_8(DataTable dataTable_0)
        {
            IDataParameter[] parameterArray;
            int num2;
            DataColumn[] primaryKey = dataTable_0.PrimaryKey;
            if ((primaryKey == null) || (primaryKey.Length == 0))
            {
                parameterArray = this.method_7(dataTable_0);
            }
            else
            {
                parameterArray = this.idbCommandHelp_0.CreateParameters(primaryKey.Length);
                for (num2 = 0; num2 < primaryKey.Length; num2++)
                {
                    parameterArray[num2] = this.method_9(primaryKey[num2]);
                }
            }
            for (num2 = 0; num2 < parameterArray.Length; num2++)
            {
                parameterArray[num2].SourceVersion = DataRowVersion.Original;
                parameterArray[num2].ParameterName = "Original_" + parameterArray[num2].ParameterName;
            }
            return parameterArray;
        }

        private IDataParameter method_9(DataColumn dataColumn_0)
        {
            IDataParameter parameter;
            if (dataColumn_0.DataType == typeof(DateTime))
            {
                parameter = this.idbCommandHelp_0.CreateParameter(dataColumn_0.ColumnName, ColumnType.DateTime, 20);
            }
            else if (Convert.ToString(dataColumn_0.ExtendedProperties["FIELDTYPE"]) == "CLOB")
            {
                if (this.idbCommandHelp_0 is CommandHelp4Oracle)
                {
                    parameter = this.idbCommandHelp_0.CreateParameter(dataColumn_0.ColumnName, ColumnType.Text);
                }
                else
                {
                    parameter = this.idbCommandHelp_0.CreateParameter(dataColumn_0.ColumnName, ColumnType.Text, 0x800);
                }
            }
            else
            {
                parameter = this.idbCommandHelp_0.CreateParameter(dataColumn_0.ColumnName, dataColumn_0.DataType);
            }
            parameter.SourceColumn = dataColumn_0.ColumnName;
            return parameter;
        }

        public virtual int Save(DataTable table)
        {
            if (!this.idbAccessSave_0.Equals(this))
            {
                return this.idbAccessSave_0.Save(table);
            }
            DbDataAdapter adapter = this.idbCommandHelp_0.CreateDbDataAdapter(null);
            ((IDbDataAdapter) adapter).UpdateCommand = this.method_4(table);
            ((IDbDataAdapter) adapter).InsertCommand = this.method_5(table);
            ((IDbDataAdapter) adapter).DeleteCommand = this.method_6(table);
            return this.method_0(adapter, table);
        }

        public virtual int Save(DataTable[] tables)
        {
            bool flag;
            if (!this.idbAccessSave_0.Equals(this))
            {
                return this.idbAccessSave_0.Save(tables);
            }
            int num4 = 0;
            if (!(flag = this.idbHelp_0.TranscationIsOpen))
            {
                this.idbHelp_0.BeginTransaction();
            }
            DataTable changes = null;
            try
            {
                int num3;
                for (num3 = tables.Length - 1; num3 >= 0; num3--)
                {
                    changes = tables[num3].GetChanges(DataRowState.Deleted);
                    if (changes != null)
                    {
                        num4 += this.method_1(changes);
                    }
                }
                for (num3 = 0; num3 < tables.Length; num3++)
                {
                    changes = tables[num3].GetChanges(DataRowState.Modified | DataRowState.Added);
                    if (changes != null)
                    {
                        num4 += this.method_3(changes);
                    }
                }
                if (!flag)
                {
                    this.idbHelp_0.CommitTransaction();
                }
            }
            catch (Exception exception)
            {
                string str = (changes != null) ? changes.TableName : string.Empty;
                LoggerManager.Error("保存数据错误，表名=" + str, exception);
                if (!flag)
                {
                    this.idbHelp_0.RollbackTransaction();
                }
                throw new Exception(string.Format("保存数据错误，表名={0}，错误信息={1}", str, exception.Message));
            }
            return num4;
        }

        protected int SaveInsert(DataTable table)
        {
            using (DbDataAdapter adapter = this.idbCommandHelp_0.CreateDbDataAdapter(null))
            {
                ((IDbDataAdapter) adapter).InsertCommand = this.method_5(table);
                return this.method_0(adapter, table);
            }
        }

        public IDbCommandHelp DbCommandHelp
        {
            get
            {
                return this.idbCommandHelp_0;
            }
        }

        public IDbHelp DbHelp
        {
            get
            {
                return this.idbHelp_0;
            }
        }
    }
}

