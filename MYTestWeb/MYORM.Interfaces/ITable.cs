using System.Collections.Generic;
using MYORM.Conditions;

namespace MYORM.Interfaces
{
    public interface ITable<T>
    {
        void Insert(T item);
        void Delete(T item);
        void Delete(IList<MYDBCondition> conds);
        void Update(T item, IList<MYDBCondition> conds);
        void Where(IList<MYDBCondition> conds, System.Data.Common.DbParameter[] dbParams);
        void Join(params MYDBQJoin[] joinTables);
        IList<T> Select(params string[] fields);
        IList<T> Select(int page, int pageNum, OrderBy pageOrder, params string[] fields);
        object SelectFeild(string fieldName, IList<MYDBCondition> conds);
    }
}
