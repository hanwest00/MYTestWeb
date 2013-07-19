using System.Collections.Generic;
using MYORM.Interfaces;
using MYORM.Conditions;

namespace Data
{
    public interface IDataGeneric<T>
    {
        void Insert(T item);
        void Update(T item);
        void Update<VT>(T item, string fieldName, VT fieldValue);
        void Remove(T item);
        void Remove<VT>(string fieldName, VT fieldValue);
        IList<T> GetAll(string[] fields, params MYDBCondition[] conds);
        IList<T> GetAll(string[] fields, int page, int pageNum, OrderBy pageOrder, params MYDBCondition[] conds);
        object GetFeildValue(string fieldName, params MYDBCondition[] conds);
    }
}
