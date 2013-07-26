using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBusiness;
using MYORM.Conditions;
using DataModels;

namespace Business
{
    public class UserBIZ
    {
        public IList<User> GetUserList(int page, int pageSize, int gId)
        {
            return DataCollection.UserInstance.GetAll(null, page, pageSize, new OrderBy("id", "order"), null, gId > 0 ? new Equal(MYDBLogic.AND, "gId", gId.ToString()) : null);
        }

        public User GetUserList(string loginName, string password)
        {
            try
            {
                IList<User> tmp = DataCollection.UserInstance.GetAll(null, new Equal(MYDBLogic.AND, "loginName", loginName.ToString()), new Equal(MYDBLogic.AND, "password", password.ToString()));
                if (tmp != null && tmp.Count > 0) return tmp[0];
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddUser(User user)
        {
            DataCollection.UserInstance.Insert(user);
        }

        public void ModifyUser(User user)
        {
            DataCollection.UserInstance.Update(user);
        }

        public void RemoveUser(User user)
        {
            DataCollection.UserInstance.Remove(user);
        }

    }
}
