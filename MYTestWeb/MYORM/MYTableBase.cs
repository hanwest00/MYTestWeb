using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Attributes;

namespace MYORM
{
    public abstract class MYTableBase<T> where T : MYItemBase
    {
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
                return (Attribute.GetCustomAttribute(TableType.Assembly, typeof(Table)) as Table).Name;
            }
        }

        public abstract void Insert(T item);
        public abstract void Delete(T item);
        public abstract void Update(T item);
        public abstract void Where(IList<MYDBCondition> conds);
        public abstract void Join(params MYDBQJoin[] joinTables);
        public abstract void Union(params MYTableBase<T>[] Tables);
        public abstract IList<T> Select();

    }
}
