using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Attributes;
using System.Data.SqlClient;
using System.Data.Common;

namespace MYORM.SqlServer
{
    public class SqlServerTable<T> : MYTableBase<T> where T : MYItemBase
    {
        private SqlServerDB sqlDB = SqlServerDB.GetInstance();
        private string whereCondition = string.Empty;

        public SqlServerTable()
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
            StringBuilder sb = new StringBuilder("insert into ");
            StringBuilder valueSb = new StringBuilder("values(");
            IList<DbParameter> sqlParams = new List<DbParameter>();
            sb.Append(TableName);
            sb.Append(" (");
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

        public override void Delete(T item, IList<MYDBCondition> conds)
        {
            StringBuilder sb = new StringBuilder("delete from ");
            sb.Append(TableName);
            sb.Append(" ");
            

            try
            {
                if (conds != null && conds.Count > 0)
                {
                    sb.Append("where ");
                    conds.ToList().ForEach(s =>{
                        sb.Append(s.ToQueryString());
                    });
                    sqlDB.dbExe.ExeNonQuery(null, sb.ToString(), null);
                    return;
                }

                IList<DbParameter> sqlParams = new List<DbParameter>();
                bool firstProp = true;
                TableType.GetProperties().ToList().ForEach(s =>
                {
                    object propValue = s.GetValue(item, null);
                    if (propValue != null)
                    {
                        if (!firstProp)
                            sb.Append("where ");
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
        public override void Update(T item, IList<MYDBCondition> conds)
        { 
           
        }
        public override void Where(IList<MYDBCondition> conds)
        { }
        public override void Join(params MYDBQJoin[] joinTables)
        { }
        public override void Union(params MYTableBase<T>[] Tables)
        { }
        public override IList<T> Select(params string[] fields)
        {
            return null;
        }
    }
}
