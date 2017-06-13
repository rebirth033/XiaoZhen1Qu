namespace TianWen.Persistence
{
    using System;
    using System.ComponentModel.Composition;
    using System.Data;
    using TianWen.Exceptions;
    using TianWen.Plus4MEF;

    [PartCreationPolicy(CreationPolicy.NonShared), TianWenComponent("DbAccessOnlyInsert")]
    public class DbAccessOnlyInsert : OldDbAccess
    {
        public override int Save(DataTable table)
        {
            DataTable table2 = table.Copy();
            table2.Clear();
            foreach (DataRow row in table.Rows)
            {
                table2.Rows.Add(row.ItemArray);
            }
            return base.SaveInsert(table2);
        }

        public override int Save(DataTable[] tables)
        {
            int num2 = 0;
            if (!base.DbHelp.TranscationIsOpen)
            {
                base.DbHelp.BeginTransaction();
            }
            try
            {
                foreach (DataTable table in tables)
                {
                    num2 += this.Save(table);
                }
                base.DbHelp.CommitTransaction();
            }
            catch (Exception exception)
            {
                base.DbHelp.RollbackTransaction();
                throw ExceptionManager.Instance.CreateException("0100210031", exception);
            }
            return num2;
        }
    }
}

