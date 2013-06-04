using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using MYORM.Exceptions;

namespace MYORM
{
    public abstract class MYDBEXE
    {
        public string ConnectString
        {
            get;
            set;
        }

        protected MYDBEXE(string connString)
        {
            ConnectString = connString;
        }

        public abstract int ExeNonQuery(string dbConnString, string queryString, IList<DbParameter> sqlParams);

        public abstract int ExeNonQuery(string dbConnString, string queryString, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract int ExeNonQuery(string dbConnString, string queryString, CommandType type, IList<DbParameter> sqlParams);

        public abstract int ExeNonQuery(string dbConnString, string queryString, CommandType type, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract DbDataReader ExeReader(string dbConnString, string queryString, IList<DbParameter> sqlParams);

        public abstract DbDataReader ExeReader(string dbConnString, string queryString, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract DbDataReader ExeReader(string dbConnString, string queryString, CommandType type, IList<DbParameter> sqlParams);

        public abstract DbDataReader ExeReader(string dbConnString, string queryString, CommandType type, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract DataTable ExeReaderToDataTable(string dbConnString, string queryString, IList<DbParameter> sqlParams);

        public abstract DataTable ExeReaderToDataTable(string dbConnString, string queryString, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract DataTable ExeReaderToDataTable(string dbConnString, string queryString, CommandType type, IList<DbParameter> sqlParams);

        public abstract DataTable ExeReaderToDataTable(string dbConnString, string queryString, CommandType type, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract IList<T> ExeReaderToList<T>(string dbConnString, string queryString, IList<DbParameter> sqlParams);

        public abstract IList<T> ExeReaderToList<T>(string dbConnString, string queryString, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract IList<T> ExeReaderToList<T>(string dbConnString, string queryString, CommandType type, IList<DbParameter> sqlParams);

        public abstract IList<T> ExeReaderToList<T>(string dbConnString, string queryString, CommandType type, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract object ExeScalar(string dbConnString, string queryString, IList<DbParameter> sqlParams);

        public abstract object ExeScalar(string dbConnString, string queryString, DbTransaction tran, IList<DbParameter> sqlParams);

        public abstract object ExeScalar(string dbConnString, string queryString, CommandType type, IList<DbParameter> sqlParams);

        public abstract object ExeScalar(string dbConnString, string queryString, CommandType type, DbTransaction tran, IList<DbParameter> sqlParams);

        protected abstract DbConnection MakeConnect(string dbConnString);

        protected void MakeCommand(string queryString, CommandType type, DbTransaction tran, ref DbConnection conn, IList<DbParameter> sqlParams, out DbCommand command)
        {
            if (conn == null)
                throw new ConnectionNullExpection("Connection null!");

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();
                command.CommandText = queryString;
                command.CommandType = type;
                if (tran != null)
                    command.Transaction = tran;
                if (sqlParams != null && sqlParams.Count > 0)
                    command.Parameters.AddRange(sqlParams.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 通过反射绑定实体对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="reader">DataReader</param>
        /// <returns>实体对象</returns>
        protected T InfoBinder<T>(IDataReader reader)
        {
            using (reader)
            {
                Type infoType = typeof(T);
                if (!reader.Read())
                    return default(T);
                T model = Activator.CreateInstance<T>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    System.Reflection.PropertyInfo pInfo = infoType.GetProperty(reader.GetName(i));
                    pInfo.SetValue(model, reader.IsDBNull(i) ? null : reader[i], null);
                }
                return model;

            }
        }

        protected IList<T> InfosBinder<T>(IDataReader reader)
        {
            using (reader)
            {
                IList<T> list = new List<T>();
                Type infoType = typeof(T);
                while (reader.Read())
                {
                    T model = Activator.CreateInstance<T>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        System.Reflection.PropertyInfo pInfo = infoType.GetProperty(reader.GetName(i));
                        if (pInfo == null)
                            continue;
                        pInfo.SetValue(model, reader[i] == null ? null : reader[i], null);
                    }
                    list.Add(model);
                }
                return list;
            }
        }
    }
}
