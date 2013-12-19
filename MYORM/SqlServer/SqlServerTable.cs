using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Attributes;
using MYORM.Conditions;
using System.Data.SqlClient;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.CodeDom;

namespace MYORM.SqlServer
{
    public class SqlServerTable<T> : MYTableBase<T>, Interfaces.ITable<T> where T : MYORM.MYItemBase
    {
        private SqlServerDB sqlDB = SqlServerDB.GetInstance();

        #region Singleton
        private static SqlServerTable<T> instance = null;
        private static object lockObj = new object();
        public static Interfaces.ITable<T> GetInstance()
        {
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
            catch (Exception)
            {
                throw;
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
                        sb.Append(" [");
                        sb.Append(s.Name);
                        sb.Append("] ");
                        valueSb.Append(s.Name);
                        sqlParams.Add(new SqlParameter(string.Format("@{0}", s.Name), propValue));
                    }
                });
                sb.Append(")");
                valueSb.Append(")");
                sb.Append(valueSb.ToString());
                sqlDB.dbExe.ExeNonQuery(null, sb.ToString(), sqlParams);
            }
            catch (Exception)
            {
                throw;
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
                            sb.Append(" where 1 = 1 and");
                        else
                            sb.Append(" and ");
                        firstProp = false;
                        sb.Append(" [");
                        sb.Append(s.Name);
                        sb.Append("] ");
                        sb.Append(" = @");
                        sb.Append(s.Name);
                        sqlParams.Add(new SqlParameter(string.Format("@{0}", s.Name), propValue));
                    }
                });

                sqlDB.dbExe.ExeNonQuery(null, sb.ToString(), sqlParams);
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
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
                        sb.Append(" [");
                        sb.Append(s.Name);
                        sb.Append("] ");
                        sb.Append(" = @");
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
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 构建Select条件子句,只在Select方法中有效
        /// </summary>
        /// <remarks>确保OrderBy,GroupBy在条件集合的末尾</remarks>
        /// <param name="conds">条件集合</param>
        /// <param name="sqlParams">参数集合</param>
        public override void Where(IList<MYDBCondition> conds,params DbParameter[] sqlParams)
        {
            if (conds != null)
            {
                if (whereQuery == null) whereQuery = new StringBuilder();
                conds.ToList().ForEach(s =>
                {
                    if (s != null) whereQuery.Append(s.ToQueryString());
                });
            }
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
            {
                if (joinQuery == null) joinQuery = new StringBuilder();
                joinTables.ToList().ForEach(s =>
                {
                    joinQuery.Append(s.ToQueryString());
                });
            }
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
            return this.Select(0, 0, null, fields);
        }

        public override IList<T> Select(int page, int pageNum, OrderBy pageOrder, params string[] fields)
        {
            return this.Select(page, pageNum, pageOrder, null, fields);
        }
		
		/// <summary>
        /// Select 分页查询
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageNum">每页数量</param>
        /// <param name="pageOrder">row_number order</param>
        /// <param name="rowConds">row_number conditions</param>
        /// <param name="fields">需要查询的字段,可包含关键字和sql函数</param>
        /// <returns>结果集合</returns>
        public override IList<T> Select(int page, int pageNum, OrderBy pageOrder, IList<MYDBCondition> rowConds, params string[] fields)
		{
			StringBuilder sb = new StringBuilder("select ");
            bool first = true;
            bool isPage = false;
            try
            {
                if (page > 0 && pageOrder != null)
                    isPage = true;

                if (fields != null && fields.Length > 0)
                {
                    foreach (string s in fields)
                    {
                        if (!first)
                            sb.Append(",");
                        first = false;
                        if (TableType.GetProperty(s) == null)
                            sb.Append(s);
                        else
                        {
                            sb.Append(" [");
                            sb.Append(s);
                            sb.Append("] ");
                        }
                    }
                }
                else
                    sb.Append(" * ");

                if (isPage)
                {
                    StringBuilder sb1 = new StringBuilder();
                    if (rowConds != null) foreach (MYDBCondition c in rowConds) sb1.Append(c.ToQueryString());
                    sb.Append(string.Format("from (select *,row_number() over({0}) as row from [{1}] where 1 = 1 {2}) as t ", pageOrder.ToQueryString(), TableName, sb1.ToString()));
                }
                else
                {
                    sb.Append(" from [");
                    sb.Append(TableName);
                    sb.Append("] ");
                }

                if (joinQuery != null)
                {
                    sb.Append(joinQuery.ToString());
                    joinQuery.Length = 0;
                }

                sb.Append(" where 1 = 1 ");

                if (isPage) sb.Append(string.Format("and row between {0} and {1} ", (page - 1) * pageNum + 1, page * pageNum));

                if (whereQuery != null)
                {
                    sb.Append(whereQuery.ToString());
                    whereQuery.Length = 0;
                }

                return sqlDB.dbExe.ExeReaderToList<T>(null, sb.ToString(), selectParams);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                selectParams = null;
            }
		}

        /// <summary>
        /// 查询单个字段的值
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="conds">条件</param>
        /// <returns></returns>
        public override object SelectFeild(string fieldName, IList<MYDBCondition> conds)
        {
            if (string.IsNullOrEmpty(fieldName)) return null;
            StringBuilder sb = new StringBuilder("select ");

            if (TableType.GetProperty(fieldName) == null)
                sb.Append(fieldName);
            else
            {
                sb.Append(" [");
                sb.Append(fieldName);
                sb.Append("] ");
            }

            sb.Append(" from [");
            sb.Append(TableName);
            sb.Append("] ");

            if (joinQuery != null)
            {
                sb.Append(joinQuery.ToString());
                joinQuery.Length = 0;
            }

            sb.Append(" where 1 = 1 ");

            if (conds != null && conds.Count > 0)
            {
                conds.ToList().ForEach(s =>
                {
                    sb.Append(s.ToQueryString());
                });
            }
            return sqlDB.dbExe.ExeScalar(null, sb.ToString(), null);
        }

    }
}
