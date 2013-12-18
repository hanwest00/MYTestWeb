using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using DataModels;
using IBusiness;
using MYORM.Conditions;

namespace Business
{
    public class GroupBIZ : IGroupBIZ
    {
        public Group GetGroupById(int id)
        {
            return DataCollection.GroupInstance.GetAll(null, new Equal(MYDBLogic.AND, "id", id.ToString()))[0];
        }

        public Group GetGroupByUId(int uId)
        {
            return DataCollection.GroupInstance.GetAll(null, new Equal(MYDBLogic.AND, "uId", uId.ToString()))[0];
        }

        public Group GetGroupByName(string name)
        {
            return DataCollection.GroupInstance.GetAll(null, new Equal(MYDBLogic.AND, "name", string.Format("'{0}'", name)))[0];
        }

        public IList<Group> GetGroupList()
        {
            return DataCollection.GroupInstance.GetAll(null, new OrderBy("order", "asc"));
        }

        public void AddGroup(Group group)
        {
            DataCollection.GroupInstance.Insert(group);
        }

        public void ModifyGroup(Group group)
        {
            DataCollection.GroupInstance.Update(group);
        }

        public void RemoveGroup(Group group)
        {
            DataCollection.GroupInstance.Remove(group);
        }
    }
}
