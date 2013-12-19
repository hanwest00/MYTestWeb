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
        private ITable<T> orm = DataIoc<T>.GetData();

        public void Insert(T item)
        {
            try
            {
                orm.Insert(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(T item)
        {
            try
            {
                orm.Update(item, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update by field value
        /// </summary>
        /// <param name="name"></param>
        public void Update(T item, IList<MYDBCondition> conds)
        {
            try
            {
                orm.Update(item, conds);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Remove(T item)
        {
            try
            {
                orm.Delete(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update by field value
        /// </summary>
        /// <param name="name"></param>
        public void Remove(IList<MYDBCondition> conds)
        {
            try
            {
                orm.Delete(conds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<T> GetAll(string[] fields, params MYDBCondition[] conds)
        {
            try
            {
                orm.Where(conds, null);
                return orm.Select(fields);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<T> GetAll(string[] fields, int page, int pageNum, OrderBy pageOrder, MYDBQJoin[] joins, params MYDBCondition[] conds)
        {
            IList<MYDBCondition> condList = new List<MYDBCondition>();

            try
            {
                conds.ToList().ForEach(s =>
                {
                    condList.Add(s);
                });

                orm.Join(joins);
                orm.Where(condList, null);

                return orm.Select(page, pageNum, pageOrder, fields);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object GetFeildValue(string fieldName, params MYDBCondition[] conds)
        {
            return this.GetFeildValue(fieldName, null, conds);
        }
        public object GetFeildValue(string fieldName, MYDBQJoin[] joins, params MYDBCondition[] conds)
        {
            try
            {
                if (joins != null) orm.Join(joins);
                return orm.SelectFeild(fieldName, conds);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
