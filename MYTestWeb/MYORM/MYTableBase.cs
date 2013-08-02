using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using MYORM.Conditions;
using MYORM.Attributes;

namespace MYORM
{
    public abstract class MYTableBase<T> : Interfaces.ITable<T> where T : MYORM.MYItemBase
    {
        private static string tableName = string.Empty;
        [ThreadStatic]
        protected static StringBuilder whereQuery;
        [ThreadStatic]
        protected static StringBuilder joinQuery;
        [ThreadStatic]
        protected static DbParameter[] selectParams = null;

        public static Type TableType
        {
            get
            {
                return typeof(T);
            }
        }

        public static string TableName
        {
            get
            {
                if (string.IsNullOrEmpty(tableName))
                {

                    Table attr = Attribute.GetCustomAttribute(TableType, typeof(Table)) as Table;
                    if (attr != null)
                        tableName = attr.Name;
                    else
                        tableName = TableType.Name;
                }
                return tableName;
            }
        }

        public abstract void Insert(T item);
        public abstract void Delete(T item);
        public abstract void Delete(IList<MYDBCondition> conds);
        public abstract void Update(T item, IList<MYDBCondition> conds);
        public abstract void Where(IList<MYDBCondition> conds, DbParameter[] dbParams);
        public abstract void Join(params MYDBQJoin[] joinTables);
        //public abstract void Union(params MYDBQUnion[] Tables);
        public abstract IList<T> Select(params string [] fields);
        public abstract IList<T> Select(int page, int pageNum, OrderBy pageOrder, params string[] fields);
        public abstract object SelectFeild(string fieldName, IList<MYDBCondition> conds);
    }
}
