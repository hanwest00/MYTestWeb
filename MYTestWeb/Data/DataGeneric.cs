using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels;
using MYORM.Interfaces;
using MYORM.Conditions;

namespace Data
{
    public class DataGeneric<T> : IDataGeneric<T> where T : IModels
    {
        private static ITable<T> orm = DataIoc<T>.GetData();

        public void Insert(T item)
        {
            orm.Insert(item);
        }

        public void Update(T item)
        {
            orm.Update(item, null);
        }

        /// <summary>
        /// Update by field value
        /// </summary>
        /// <param name="name"></param>
        public void Update(T item, IList<MYDBCondition> conds)
        {
            orm.Update(item, conds);
        }


        public void Remove(T item)
        {
            orm.Delete(item);
        }

        /// <summary>
        /// Update by field value
        /// </summary>
        /// <param name="name"></param>
        public void Remove(IList<MYDBCondition> conds)
        {
            orm.Delete(conds);
        }

        public IList<T> GetAll(string[] fields, params MYDBCondition[] conds)
        {
            orm.Where(conds, null);
            return orm.Select(fields);
        }

        public IList<T> GetAll(string[] fields, int page, int pageNum, OrderBy pageOrder, MYDBQJoin[] joins, params MYDBCondition[] conds)
        {
            IList<MYDBCondition> condList = new List<MYDBCondition>();

            conds.ToList().ForEach(s =>
            {
                condList.Add(s);
            });

            orm.Join(joins);
            orm.Where(condList, null);

            return orm.Select(fields);
        }

        public object GetFeildValue(string fieldName, params MYDBCondition[] conds)
        {
            return orm.SelectFeild(fieldName, conds);
        }
    }
}
