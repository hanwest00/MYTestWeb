using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Tables;
using MYORM.SqlServer;
using MYORM;
using MYORM.Conditions;

namespace Business
{
    public class Users
    {
        private static SqlServerTable<User> user = SqlServerTable<User>.GetInstance();

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
            conds.Add(new Equal(MYDBLogic.NOTSET, "name", name, name));
            user.Delete(conds);
        }

        public IList<Data.Tables.User> GetAll()
        {
            user.Where(new List<MYDBCondition>() {
                 new Equal(MYDBLogic.NOTSET,"Id","@Id")
            }, new System.Data.SqlClient.SqlParameter[] { 
                new System.Data.SqlClient.SqlParameter("@Id", "12") 
            });
            return user.Select("Id", "GroupId", "Name");
        }
    }
}
