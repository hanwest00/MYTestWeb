using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels;
using MYORM;
using MYORM.Interfaces;
using MYORM.Conditions;

namespace Data
{
    public class CategoryDAL
    {
        private static ITable<Category> cate = DataIoc<Category>.GetData();

        public void Insert(Category item)
        {
            cate.Insert(item);
        }

        public void Update(Category item)
        {
            cate.Update(item, null);
        }

        /// <summary>
        /// Update by cateName
        /// </summary>
        /// <param name="name"></param>
        public void Update(Category item, string cateName)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "cateName", cateName));
            cate.Update(item, conds);
        }

        /// <summary>
        /// Update by id
        /// </summary>
        /// <param name="name"></param>
        public void Update(Category item, int id)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "id", id.ToString()));
            cate.Update(item, conds);
        }

        /// <summary>
        /// Update by pId
        /// </summary>
        /// <param name="name"></param>
        public void Update(Category item, int pId)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "pId", pId.ToString()));
            cate.Update(item, conds);
        }

        public void Remove(Category item)
        {
            cate.Delete(item);
        }

        /// <summary>
        /// Update by cateName
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string cateName)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "cateName", cateName));
            cate.Delete(conds);
        }

        /// <summary>
        /// Update by id
        /// </summary>
        /// <param name="name"></param>
        public void Remove(int id)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "id", id.ToString()));
            cate.Delete(conds);
        }

        /// <summary>
        /// Update by pId
        /// </summary>
        /// <param name="name"></param>
        public void Remove(int pId)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "pId", pId.ToString()));
            cate.Delete(conds);
        }



        public IList<Category> GetAll(List<string> fields, params MYDBCondition[] conds)
        {
            return this.GetAll(fields, null, null, null, conds);
        }

        public IList<Category> GetAll(List<string> fields, int? page, int? pageNum, OrderBy pageOrder, params MYDBCondition[] conds)
        {
            //need update
            IList<MYDBCondition> condList = new List<MYDBCondition>();
            if (fields == null) fields = new List<string> { "id", "pId", "Name" };

            if (pageNum != null && page != null)
            {
                if (pageOrder == null) pageOrder = new OrderBy("id", "asc");
                fields.Add(string.Format("row_number() over({0}) as row", pageOrder.ToQueryString()));
                condList.Add(new Between(MYDBLogic.AND, "row", (page * pageNum).ToString(), "@end"));
            }

            conds.ToList().ForEach(s =>
            {
                condList.Add(s);
            });

            cate.Where(condList, null);

            return cate.Select(fields.ToArray());
        }
    }
}
