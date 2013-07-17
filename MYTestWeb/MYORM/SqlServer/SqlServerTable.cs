using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Attributes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.CodeDom;

namespace MYORM.SqlServer
{
    public class SqlServerTable<T> : MYTableBase<T>, Interfaces.ITable<T> where T : MYItemBase
    {
        private SqlServerDB sqlDB = SqlServerDB.GetInstance();

        #region Singleton
        private static SqlServerTable<T> instance = null;
        public static Interfaces.ITable<T> GetInstance()
        {
            object lockObj = new object();
            lock (lockObj)
            {
                if (instance == null)
                    instance = new SqlServerTable<T>();
            }
            return instance;
        }
        #endregion

        private SqlServerTable()
        {
            try
            {
                sqlDB.CreateTable(typeof(T), TableName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void Insert(T item)
        {

            bool firstPorp = true;
            StringBuilder sb = new StringBuilder("insert into [");
            StringBuilder valueSb = new StringBuilder("values(");
            IList<DbParameter> sqlParams = new List<DbParameter>();
            sb.Append(TableName);
            sb.Append("] (");
            try
            {
                TableType.GetProperties().ToList().ForEach(s =>
                {
                    if (Attribute.GetCustomAttribute(s, typeof(PrimaryKey)) != null && Attribute.GetCustomAttribute(s, typeof(Identity)) != null)
                        return;

                    object propValue = s.GetValue(item, null);
                    if (propValue != null)
                    {
                        if (!firstPorp)
                        {
                            sb.Append(",");
                            valueSb.Append(",");
                        }
                        valueSb.Append("@");
                        firstPorp = false;
                        sb.Append(s.Name);
                        valueSb.Append(s.Name);
                        sqlParams.Add(new SqlParameter(string.Format("@{0}", s.Name), propValue));
                    }
                });
                sb.Append(")");
                valueSb.Append(")");
                sb.Append(valueSb.ToString());
                sqlDB.dbExe.ExeNonQuery(null, sb.ToString(), sqlParams);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void Delete(T item)
        {
            StringBuilder sb = new StringBuilder("delete from [");
            sb.Append(TableName);
            sb.Append("] ");

            try
            {
                IList<DbParameter> sqlParams = new List<DbParameter>();
                bool firstProp = true;
                TableType.GetProperties().ToList().ForEach(s =>
                {
                    object propValue = s.GetValue(item, null);
                    if (propValue != null)
                    {
                        if (firstProp)
                            sb.Append(" where 1 = 1 ");
                        else
                            sb.Append(" and ");
                        firstProp = false;
                        sb.Append(s.Name);
                        sb.Append(" = @");
                        sb.Append(s.Name);
                        sqlParams.Add(new SqlParameter(string.Format("@{0}", s.Name), propValue));
                    }
                });

                sqlDB.dbExe.ExeNonQuery(null, sb.ToString(), sqlParams);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public override void Delete(IList<MYDBCondition> conds)
        {
            StringBuilder sb = new StringBuilder("delete from [");
            sb.Append(TableName);
            sb.Append("] ");
            try
            {
                if (conds != null && conds.Count > 0)
                {
                    sb.Append(" where 1 = 1 ");
                    conds.ToList().ForEach(s =>
                    {
                        sb.Append(s.ToQueryString());
                    });
                    sqlDB.dbExe.ExeNonQuery(null, sb.ToString(), null);
                    return;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public override void Update(T item, IList<MYDBCondition> conds)
        {
            StringBuilder sb = new StringBuilder("update [");
            sb.Append(TableName);
            sb.Append("] set ");

            IList<DbParameter> sqlParams = new List<DbParameter>();
            bool firstProp = true;
            try
            {
                TableType.GetProperties().ToList().ForEach(s =>
                {
                    if (Attribute.GetCustomAttribute(s, typeof(PrimaryKey)) != null && Attribute.GetCustomAttribute(s, typeof(Identity)) != null)
                        return;

                    object propValue = s.GetValue(item, null);
                    if (propValue != null)
                    {
                        if (!firstProp)
                            sb.Append(",");
                        firstProp = false;
                        sb.Append(s.Name);
                        sb.Append("=@");
                        sb.Append(s.Name);
                        sqlParams.Add(new SqlParameter(string.Format("@{0}", s.Name), propValue));
                    }
                });

                if (conds != null && conds.Count > 0)
                {
                    sb.Append(" where 1 = 1 ");
                    conds.ToList().ForEach(s =>
                    {
                        sb.Append(s.ToQueryString());
                    });
                }
                sqlDB.dbExe.ExeNonQuery(null, sb.ToString(), sqlParams);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 构建Select条件子句,只在Select方法中有效
        /// </summary>
        /// <remarks>确保OrderBy,GroupBy在条件集合的末尾</remarks>
        /// <param name="conds">条件集合</param>
        /// <param name="sqlParams">参数集合</param>
        public override void Where(IList<MYDBCondition> conds, DbParameter[] sqlParams)
        {
            if (conds != null)
                conds.ToList().ForEach(s =>
                {
                    whereQuery.Append(s.ToQueryString());
                });

            if (sqlParams != null)
                selectParams = sqlParams;
        }
        /// <summary>
        /// 构建Select的Join子句,只在Select方法中有效
        /// </summary>
        /// <param name="joinTables">join集合</param>
        public override void Join(params MYDBQJoin[] joinTables)
        {
            if (joinTables != null)
                joinTables.ToList().ForEach(s =>
                {
                    joinQuery.Append(s.ToQueryString());
                });
        }

        //public override void Union(params MYTableBase<T>[] Tables)
        //{ }

        /// <summary>
        /// Select查询
        /// </summary>
        /// <param name="fields">需要查询的字段,可包含关键字和sql函数</param>
        /// <returns>结果集合</returns>
        public override IList<T> Select(params string[] fields)
        {
            StringBuilder sb = new StringBuilder("select ");
            bool first = true;

            try
            {
                if (fields != null && fields.Length > 0)
                    fields.ToList().ForEach(s =>
                    {
                        if (!first)
                            sb.Append(",");
                        first = false;
                        sb.Append(s);
                    });
                else
                    sb.Append("*");

                sb.Append(" from [");
                sb.Append(TableName);
                sb.Append("] ");

                if (joinQuery.Length > 0)
                {
                    sb.Append(joinQuery.ToString());
                    joinQuery.Clear();
                }

                if (whereQuery.Length > 0)
                {
                    sb.Append(" where 1 = 1 ");
                    sb.Append(whereQuery.ToString());
                    whereQuery.Clear();
                }

                return sqlDB.dbExe.ExeReaderToList<T>(null, sb.ToString(), selectParams);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public override object SelectFeild(string fieldName, IList<MYDBCondition> conds)
        {
            if (string.IsNullOrEmpty(fieldName)) return null;
            StringBuilder sb = new StringBuilder("select ");
            sb.Append(fieldName);
            if (conds != null && conds.Count > 0)
            {
                sb.Append(" where 1 = 1 ");
                conds.ToList().ForEach(s =>
                {
                    sb.Append(s.ToQueryString());
                });
            }
            return sqlDB.dbExe.ExeScalar(null, sb.ToString(), null);
        }
    }
}
