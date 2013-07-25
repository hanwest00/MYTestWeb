using System.Collections.Generic;
using MYORM.Interfaces;
using MYORM.Conditions;

namespace Data
{
    public interface IDataGeneric<T>
    {
        void Insert(T item);
        void Update(T item);
        void Update(T item, IList<MYDBCondition> conds);
        void Remove(T item);
        void Remove(IList<MYDBCondition> conds);
        IList<T> GetAll(string[] fields, params MYDBCondition[] conds);
        IList<T> GetAll(string[] fields, int page, int pageNum, OrderBy pageOrder,MYDBQJoin[] joins, params MYDBCondition[] conds);
        object GetFeildValue(string fieldName, params MYDBCondition[] conds);
    }
}
