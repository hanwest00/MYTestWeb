using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace MYORM.SqlServer
{
    public class SqlDBEXE : MYDBEXE
    {

        #region Singleton
        private static SqlDBEXE instance = null;

        public static SqlDBEXE GetInstance(string connString)
        {
            object lockObj = new object();

            System.Threading.Monitor.Enter(lockObj);
            if (instance == null)
                instance = new SqlDBEXE(connString);
            System.Threading.Monitor.Wait(lockObj);

            return instance;
        }
        #endregion

        protected SqlDBEXE(string connString)
            : base(connString)
        {

        }

        public override int ExeNonQuery(string dbConnString, string queryString, DbParameter[] sqlParams)
        {
            return ExeNonQuery(dbConnString, queryString, CommandType.Text, null, sqlParams);
        }

        public override int ExeNonQuery(string dbConnString, string queryString, DbTransaction tran, DbParameter[] sqlParams)
        {
            return ExeNonQuery(dbConnString, queryString, CommandType.Text, tran, sqlParams);
        }

        public override int ExeNonQuery(string dbConnString, string queryString, CommandType type, DbParameter[] sqlParams)
        {
            return ExeNonQuery(dbConnString, queryString, type, null, sqlParams);
        }

        public override int ExeNonQuery(string dbConnString, string queryString, CommandType type, DbTransaction tran, DbParameter[] sqlParams)
        {
            DbConnection conn = null;
            DbCommand comm = null;
            try
            {
                conn = MakeConnect(dbConnString);
                MakeCommand(queryString, type, tran, ref conn, sqlParams, out comm);
                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Dispose();
            }
        }

        public override DbDataReader ExeReader(string dbConnString, string queryString, DbParameter[] sqlParams)
        {
            return ExeReader(dbConnString, queryString, CommandType.Text, null, sqlParams);
        }

        public override DbDataReader ExeReader(string dbConnString, string queryString, CommandType type, DbParameter[] sqlParams)
        {
            return ExeReader(dbConnString, queryString, type, null, sqlParams);
        }

        public override DbDataReader ExeReader(string dbConnString, string queryString, DbTransaction tran, DbParameter[] sqlParams)
        {
            return ExeReader(dbConnString, queryString, CommandType.Text, tran, sqlParams);
        }

        public override DbDataReader ExeReader(string dbConnString, string queryString, CommandType type, DbTransaction tran, DbParameter[] sqlParams)
        {
            DbConnection conn = null;
            DbCommand comm = null;
            try
            {
                conn = MakeConnect(dbConnString);
                MakeCommand(queryString, type, tran, ref conn, sqlParams, out comm);
                return comm.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override DataTable ExeReaderToDataTable(string dbConnString, string queryString, DbParameter[] sqlParams)
        {
            return ExeReaderToDataTable(dbConnString, queryString, CommandType.Text, null, sqlParams);
        }

        public override DataTable ExeReaderToDataTable(string dbConnString, string queryString, CommandType type, DbParameter[] sqlParams)
        {
            return ExeReaderToDataTable(dbConnString, queryString, type, null, sqlParams);
        }

        public override DataTable ExeReaderToDataTable(string dbConnString, string queryString, DbTransaction tran, DbParameter[] sqlParams)
        {
            return ExeReaderToDataTable(dbConnString, queryString, CommandType.Text, tran, sqlParams);
        }

        public override DataTable ExeReaderToDataTable(string dbConnString, string queryString, CommandType type, DbTransaction tran, DbParameter[] sqlParams)
        {
            DataTable ret = new DataTable();
            DbConnection conn = null;
            DbCommand comm = null;
            DbDataAdapter adp = null;
            try
            {
                conn = MakeConnect(dbConnString);
                MakeCommand(queryString, type, tran, ref conn, sqlParams, out comm);
                adp = new SqlDataAdapter(comm as SqlCommand);
                adp.Fill(ret);
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (adp != null)
                    adp.Dispose();
                if (conn != null)
                    conn.Dispose();
            }
        }

        public override IList<MYItemBase> ExeReaderToList(string dbConnString, string queryString, DbParameter[] sqlParams)
        {
            return ExeReaderToList(dbConnString, queryString, CommandType.Text, null, sqlParams);
        }

        public override IList<MYItemBase> ExeReaderToList(string dbConnString, string queryString, DbTransaction tran, DbParameter[] sqlParams)
        {
            return ExeReaderToList(dbConnString, queryString, CommandType.Text, tran, sqlParams);
        }

        public override IList<MYItemBase> ExeReaderToList(string dbConnString, string queryString, CommandType type, DbParameter[] sqlParams)
        {
            return ExeReaderToList(dbConnString, queryString, type, null, sqlParams);
        }

        public override IList<MYItemBase> ExeReaderToList(string dbConnString, string queryString, CommandType type, DbTransaction tran, DbParameter[] sqlParams)
        {
            DbDataReader reader = null;
            try
            {
                reader = ExeReader(dbConnString, queryString, type, tran, sqlParams);
                return InfosBinder<MYItemBase>(reader);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }

        public override object ExeScalar(string dbConnString, string queryString, DbParameter[] sqlParams)
        {
            return ExeScalar(dbConnString, queryString, CommandType.Text, null, sqlParams);
        }

        public override object ExeScalar(string dbConnString, string queryString, CommandType type, DbParameter[] sqlParams)
        {
            return ExeScalar(dbConnString, queryString, type, null, sqlParams);
        }

        public override object ExeScalar(string dbConnString, string queryString, DbTransaction tran, DbParameter[] sqlParams)
        {
            return ExeScalar(dbConnString, queryString, CommandType.Text, tran, sqlParams);
        }

        public override object ExeScalar(string dbConnString, string queryString, CommandType type, DbTransaction tran, DbParameter[] sqlParams)
        {
            DbConnection conn = null;
            DbCommand comm = null;
            try
            {
                conn = MakeConnect(dbConnString);
                MakeCommand(queryString, type, tran, ref conn, sqlParams, out comm);
                return comm.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Dispose();
            }
        }

        protected override DbConnection MakeConnect(string dbConnString)
        {
            try
            {
                DbConnection conn = new SqlConnection();
                if (!string.IsNullOrEmpty(dbConnString))
                    conn.ConnectionString = dbConnString;
                else
                    conn.ConnectionString = ConnectString;
                return conn;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
