using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Attributes;
using System.Data.Common;

namespace MYORM.SqlServer
{
    public class SqlServerTable<T> : MYTableBase<T> where T : MYItemBase
    {
        private SqlServerDB sqlDB = SqlServerDB.GetInstance();

        public SqlServerTable()
        {
            try
            {
                sqlDB.CreateTable(typeof(T));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void Insert(T item)
        {
            typeof(T).GetProperties().ToList().ForEach(s => {
                s.GetValue(item, null);
            });
            sqlDB.dbExe.ExeNonQuery(null, "", null);
        }
        public override void Delete(T item)
        { }
        public override void Update(T item)
        { }
        public override void Where(IList<MYDBCondition> conds)
        { }
        public override void Join(params MYDBQJoin[] joinTables)
        { }
        public override void Union(params MYTableBase<T>[] Tables)
        { }
        public override IList<T> Select()
        {
            return null;
        }
    }
}
