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
    public class UserDAL
    {
        private static ITable<User> user = DataIoc<User>.GetData();

        public void Insert(User item)
        {
            user.Insert(item);
        }

        public void Update(User item)
        {
            user.Update(item, null);
        }

        /// <summary>
        /// Update by name
        /// </summary>
        /// <param name="name"></param>
        public void Update(User item, string name)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "name", name));
            user.Update(item, conds);
        }

        /// <summary>
        /// Update by id
        /// </summary>
        /// <param name="name"></param>
        public void Update(User item, int id)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "id", id.ToString()));
            user.Update(item, conds);
        }

        public void Remove(User item)
        {
            user.Delete(item);
        }

        /// <summary>
        /// Remove by name
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "name", name));
            user.Delete(conds);
        }

        /// <summary>
        /// Remove by id
        /// </summary>
        /// <param name="name"></param>
        public void Remove(int id)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.AND, "id", id.ToString()));
            user.Delete(conds);
        }

        public IList<User> GetAll(string[] fields,params MYDBCondition[] conds)
        {
            return this.GetAll(fields,null, null, null, conds);
        }

        public IList<User> GetAll(string[] fields,int? page, int? pageNum, OrderBy pageOrder, params MYDBCondition[] conds)
        {
            //need update
            IList<MYDBCondition> condList = new List<MYDBCondition>();
            if (pageNum == null || page == null)
                fields = new string[] { "id", "groupId", "name" };
            else
            {
                if (pageOrder == null) pageOrder = new OrderBy("id", "asc");
                fields = new string[] { string.Format("row_number() over({0}) as row", pageOrder.ToQueryString()), "id", "groupId", "name" };
                condList.Add(new Between(MYDBLogic.AND, "row", "@start", "@end"));
            }

            conds.ToList().ForEach(s =>
            {
                condList.Add(s);
            });

            user.Where(condList, null);

            return user.Select(fields);
        }
    }
}
