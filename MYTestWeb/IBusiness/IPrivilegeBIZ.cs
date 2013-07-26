using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface IPrivilegeBIZ
    {
       IList<Privilege> GetPrivilegeByCId(int cId);

       IList<Privilege> GetPrivilegeByUId(int uId);

       Privilege GetPrivilegeByCIdAndUId(int cId, int uId);

       void AddPrivilege(Privilege privilege);

       void RemovePrivilege(Privilege privilege);

       void ModifyPrivilege(Privilege privilege);
    }
}
