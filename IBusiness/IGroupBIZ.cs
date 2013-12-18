using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface IGroupBIZ
    {
        Group GetGroupById(int id);
        Group GetGroupByUId(int uId);
        Group GetGroupByName(string name);
        IList<Group> GetGroupList();
        void AddGroup(Group group);
        void ModifyGroup(Group group);
        void RemoveGroup(Group group);
    }
}
