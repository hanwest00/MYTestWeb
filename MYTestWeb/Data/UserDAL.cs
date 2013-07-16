using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels;
using MYORM.SqlServer;
using MYORM;
using MYORM.Interfaces;
using MYORM.Conditions;

namespace Data
{
    public class UserDAL
    {
        private static ITable<User> user = SqlServerTable<User>.GetInstance();

        public void Insert(User item)
        {
            user.Insert(item);
        }

        public void Remove(User item)
        {
            user.Delete(item);
        }

        public void Remove(string name)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.NOTSET, "name", name));
            user.Delete(conds);
        }

        public IList<User> GetAll()
        {
            user.Where(new List<MYDBCondition>() {
                 new Equal(MYDBLogic.NOTSET,"Id","@Id")
            }, new System.Data.SqlClient.SqlParameter[] { 
                new System.Data.SqlClient.SqlParameter("@Id", "12") 
            });

            return user.Select("Id", "GroupId", "Name");
        }

        public IList<User> GetAll(int? page, int? pageNum, OrderBy pageOrder, params MYDBCondition[] conds)
        {
            string[] fields;
            IList<MYDBCondition> condList = new List<MYDBCondition>();
            if (pageNum == null || page == null)
                fields = new string[] { "Id", "GroupId", "Name" };
            else
            {
                if (pageOrder == null) pageOrder = new OrderBy("Id", "asc");
                fields = new string[] { string.Format("row_number() over({0}) as row", pageOrder.ToQueryString()), "Id", "GroupId", "Name" };
                condList.Add(new Between(MYDBLogic.NOTSET, "row", "@start", "@end"));
            }

            conds.ToList().ForEach(s => {
                condList.Add(s);
            });

            user.Where(condList, null);

            return user.Select(fields);
        }
    }
}
