namespace TianWen.Nhibernate.Repository
{
    using NHibernate;
    using NHibernate.Criterion;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class AbstractRepository : IRepository
    {
        protected virtual void AttachParameters(IDbCommand command, IDataParameter[] commandParameters)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (commandParameters != null)
            {
                foreach (IDataParameter parameter in commandParameters)
                {
                    if (parameter != null)
                    {
                        if (((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Input)) && (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add((parameter.DbType == DbType.Binary) ? this.GetBlobParameter(parameter) : parameter);
                    }
                }
            }
        }

        public virtual void BeginDbTransaction()
        {
            if (this.DbTransaction == null)
            {
                this.DbTransaction = this.Session.Connection.BeginTransaction();
            }
        }

        public virtual void BeginTransaction()
        {
            if ((this.Transaction == null) || !this.Transaction.IsActive)
            {
                this.Transaction = this.Session.BeginTransaction();
            }
        }

        public virtual void Commit()
        {
            try
            {
                if (this.Transaction != null)
                {
                    this.Transaction.Commit();
                }
            }
            catch (Exception)
            {
                if (this.Transaction != null)
                {
                    this.Transaction.Rollback();
                }
            }
        }

        public virtual void DbCommit()
        {
            try
            {
                if (this.DbTransaction != null)
                {
                    this.DbTransaction.Commit();
                }
            }
            catch (Exception)
            {
                if (this.Transaction != null)
                {
                    this.Transaction.Rollback();
                }
            }
        }

        public virtual void DbRollback()
        {
            if (this.DbTransaction != null)
            {
                this.DbTransaction.Rollback();
            }
        }

        public virtual void Delete(object o)
        {
            this.Session.Delete(o);
            this.Session.Flush();
        }

        public virtual void Delete<T>(object id)
        {
            object objectById = this.GetObjectById<T>(id);
            this.Session.Delete(objectById);
            this.Session.Flush();
        }

        public virtual IList<T> DoPageList<T>(string condition, int currentPageIndex, int pageSize, out int recordCount)
        {
            recordCount = 0;
            string queryString = condition;
            IQuery query = this.Session.CreateQuery(queryString);
            condition = "select count(*)  " + condition + " ";
            IList<object> objectList = this.GetObjectList<object>(condition);
            recordCount = (int.Parse(objectList[0].ToString()) < 1) ? 0 : int.Parse(objectList[0].ToString());
            query.SetFirstResult((currentPageIndex - 1) * pageSize).SetMaxResults(pageSize);
            return query.List<T>();
        }

        public virtual IList<T> DoPageList<T>(string cols, string condition, int currentPageIndex, int pageSize, out int recordCount)
        {
            recordCount = 0;
            string queryString = "";
            if (string.IsNullOrEmpty(cols))
            {
                queryString = condition;
            }
            else
            {
                queryString = "select " + cols + " " + condition;
            }
            IQuery query = this.Session.CreateQuery(queryString);
            condition = "select count(*) " + condition;
            IList<object> objectList = this.GetObjectList<object>(condition);
            recordCount = (int.Parse(objectList[0].ToString()) < 1) ? 0 : int.Parse(objectList[0].ToString());
            query.SetFirstResult((currentPageIndex - 1) * pageSize).SetMaxResults(pageSize);
            return query.List<T>();
        }

        public virtual int ExecuteNonQuery(string sql)
        {
            IDbCommand command = this.Session.Connection.CreateCommand();
            command.CommandText = sql;
            if (this.DbTransaction != null)
            {
                command.Transaction = this.DbTransaction;
            }
            return command.ExecuteNonQuery();
        }

        public virtual int ExecuteNonQuery(string sql, CommandType commandType, IDataParameter[] commandParameters)
        {
            IDbCommand command = this.Session.Connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = commandType;
            if (this.DbTransaction != null)
            {
                command.Transaction = this.DbTransaction;
            }
            this.AttachParameters(command, commandParameters);
            return command.ExecuteNonQuery();
        }

        public virtual object ExecuteScalar(string sql)
        {
            IDbCommand command = this.Session.Connection.CreateCommand();
            command.CommandText = sql;
            if (this.DbTransaction != null)
            {
                command.Transaction = this.DbTransaction;
            }
            return command.ExecuteScalar();
        }

        public virtual object ExecuteScalar(string sql, CommandType commandType, IDataParameter[] commandParameters)
        {
            IDbCommand command = this.Session.Connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = commandType;
            if (this.DbTransaction != null)
            {
                command.Transaction = this.DbTransaction;
            }
            this.AttachParameters(command, commandParameters);
            return command.ExecuteScalar();
        }

        protected virtual IDataParameter GetBlobParameter(IDataParameter p)
        {
            if (TianWen.Nhibernate.Repository.DataBaseType.Oracle == this.DataBaseType)
            {
                return new OracleParameter(p.ParameterName, OracleType.Blob) { Value = p.Value };
            }
            return p;
        }

        public virtual DataSet GetDataSet(string sql)
        {
            IDbDataAdapter adapter;
            DataSet dataSet = new DataSet();
            IDbCommand command = this.Session.Connection.CreateCommand();
            command.CommandText = sql;
            if (this.DbTransaction != null)
            {
                command.Transaction = this.DbTransaction;
            }
            if (this.DataBaseType == TianWen.Nhibernate.Repository.DataBaseType.Oracle)
            {
                adapter = new OracleDataAdapter(command as OracleCommand);
            }
            else
            {
                adapter = new SqlDataAdapter(command as SqlCommand);
            }
            adapter.Fill(dataSet);
            return dataSet;
        }

        public virtual DataSet GetDataSet(string sql, CommandType commandType, IDataParameter[] commandParameters)
        {
            IDbDataAdapter adapter;
            DataSet dataSet = new DataSet();
            IDbCommand command = this.Session.Connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = commandType;
            if (this.DbTransaction != null)
            {
                command.Transaction = this.DbTransaction;
            }
            this.AttachParameters(command, commandParameters);
            if (this.DataBaseType == TianWen.Nhibernate.Repository.DataBaseType.Oracle)
            {
                adapter = new OracleDataAdapter(command as OracleCommand);
            }
            else
            {
                adapter = new SqlDataAdapter(command as SqlCommand);
            }
            adapter.Fill(dataSet);
            return dataSet;
        }

        public virtual DataTable GetDataTable(string sql)
        {
            return this.GetDataSet(sql).Tables[0];
        }

        public virtual DataTable GetDataTable(string sql, CommandType commandType, IDataParameter[] commandParameters)
        {
            return this.GetDataSet(sql, commandType, commandParameters).Tables[0];
        }

        public virtual T GetObjectById<T>(object id)
        {
            return this.Session.Get<T>(id);
        }

        public virtual IList<T> GetObjectList<T>(string strWhere)
        {
            return this.Session.CreateQuery(strWhere).List<T>();
        }

        public virtual IList<T> GetObjectList<T>(string hql, int max)
        {
            IQuery query = this.Session.CreateQuery(hql);
            query.SetMaxResults(max);
            return query.List<T>();
        }

        public virtual IList<T> GetObjectList<T>(string hql, object arg)
        {
            IQuery query = this.Session.CreateQuery(hql);
            query.SetParameter(0, arg);
            return query.List<T>();
        }

        public virtual IList<T> GetObjectList<T>(string hql, params object[] arg)
        {
            IQuery query = this.Session.CreateQuery(hql);
            if (arg != null)
            {
                for (int i = 0; i < arg.Length; i++)
                {
                    query.SetParameter(i, arg[i]);
                }
            }
            return query.List<T>();
        }

        public virtual IList<T> GetObjectList<T>(string hql, int max, object arg)
        {
            IQuery query = this.Session.CreateQuery(hql);
            query.SetParameter(0, arg);
            query.SetMaxResults(max);
            return query.List<T>();
        }

        public virtual IList<T> GetObjectList<T>(string hql, int max, params object[] arg)
        {
            IQuery query = this.Session.CreateQuery(hql);
            if (arg != null)
            {
                for (int i = 0; i < arg.Length; i++)
                {
                    query.SetParameter(i, arg[i]);
                }
            }
            query.SetMaxResults(max);
            return query.List<T>();
        }

        public virtual IList<T> GetObjList<T>()
        {
            return this.Session.CreateCriteria(typeof(T)).List<T>();
        }

        public virtual IList<T> GetObjListByFk<T>(string key, object value)
        {
            return this.Session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(key, value)).AddOrder(new Order(key, true)).List<T>();
        }

        public virtual void Rollback()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Rollback();
            }
        }

        public virtual void Save(object o)
        {
            this.SavePreview(o);
            this.Session.Flush();
        }

        public virtual void SaveForTransaction(object o)
        {
            ITransaction transaction = this.Session.BeginTransaction();
            try
            {
                this.SavePreview(o);
                this.Session.Flush();
                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                throw new Exception(exception.Message, exception.InnerException);
            }
        }

        public virtual void SaveOrUpdate(object o)
        {
            this.SaveOrUpdatePreview(o);
            this.Session.Flush();
        }

        public virtual void SaveOrUpdateForTransaction(object o)
        {
            ITransaction transaction = this.Session.BeginTransaction();
            try
            {
                try
                {
                    this.SaveOrUpdatePreview(o);
                    this.Session.Flush();
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw new Exception(exception.Message, exception.InnerException);
                }
            }
            finally
            {
            }
        }

        internal virtual void SaveOrUpdatePreview(object o)
        {
            try
            {
                this.Session.SaveOrUpdate(o);
            }
            catch (NonUniqueObjectException exception)
            {
                if (exception.Message.StartsWith("a different object with the same identifier value was already associated with the session"))
                {
                    this.Session.Merge(o);
                }
            }
        }

        internal virtual void SavePreview(object o)
        {
            try
            {
                this.Session.Save(o);
            }
            catch (NonUniqueObjectException exception)
            {
                if (exception.Message.StartsWith("a different object with the same identifier value was already associated with the session"))
                {
                    this.Session.Merge(o);
                }
            }
        }

        protected void setDataBaseType(string dbName)
        {
            string str = DbFactory.Instance.mfp.Properties[dbName]["connection.driver_class"];
            if ((str != null) && (str == "NHibernate.Driver.OracleClientDriver"))
            {
                this.DataBaseType = TianWen.Nhibernate.Repository.DataBaseType.Oracle;
            }
        }

        public virtual void StatelessInsert<T>(IList<T> objs)
        {
            IStatelessSession statelessSession = this.StatelessSession;
            using (statelessSession)
            {
                using (ITransaction transaction = statelessSession.BeginTransaction())
                {
                    try
                    {
                        foreach (T local in objs)
                        {
                            statelessSession.Insert(local);
                        }
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        throw new Exception(exception.Message, exception.InnerException);
                    }
                }
            }
        }

        public virtual void StatelessUpdate<T>(IList<T> objs)
        {
            IStatelessSession statelessSession = this.StatelessSession;
            using (statelessSession)
            {
                using (ITransaction transaction = statelessSession.BeginTransaction())
                {
                    try
                    {
                        foreach (T local in objs)
                        {
                            statelessSession.Update(local);
                        }
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        throw new Exception(exception.Message, exception.InnerException);
                    }
                }
            }
        }

        public virtual void Update(object o)
        {
            this.Session.Update(o);
            this.Session.Flush();
        }

        public virtual void UpdateForTransaction(object o)
        {
            ITransaction transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.Update(o);
                this.Session.Flush();
                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                throw new Exception(exception.Message, exception.InnerException);
            }
        }

        public virtual TianWen.Nhibernate.Repository.DataBaseType DataBaseType { get; set; }

        public virtual IDbTransaction DbTransaction { get; set; }

        public virtual ISession Session
        {
            get
            {
                return null;
            }
        }

        public virtual IStatelessSession StatelessSession
        {
            get
            {
                return null;
            }
        }

        public virtual ITransaction Transaction { get; set; }
    }
}

