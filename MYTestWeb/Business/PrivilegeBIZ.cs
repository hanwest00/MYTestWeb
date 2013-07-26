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
    public class PrivilegeBIZ : IPrivilegeBIZ
    {
        public IList<Privilege> GetPrivilegeByCId(int cId)
        {
            return DataCollection.PrivilegeInstance.GetAll(null, new Equal(MYDBLogic.AND, "cId", cId.ToString()));
        }

        public IList<Privilege> GetPrivilegeByUId(int uId)
        {
            return DataCollection.PrivilegeInstance.GetAll(null, new Equal(MYDBLogic.AND, "uId", uId.ToString()));
        }

        public Privilege GetPrivilegeByCIdAndUId(int cId, int uId)
        {
            return DataCollection.PrivilegeInstance.GetAll(null, new Equal(MYDBLogic.AND, "cId", cId.ToString()), new Equal(MYDBLogic.AND, "uId", uId.ToString()))[0];
        }

        public void AddPrivilege(Privilege privilege)
        {
            DataCollection.PrivilegeInstance.Insert(privilege);
        }

        public void RemovePrivilege(Privilege privilege)
        {
            DataCollection.PrivilegeInstance.Remove(privilege);
        }

        public void ModifyPrivilege(Privilege privilege)
        {
            DataCollection.PrivilegeInstance.Update(privilege);
        }
    }
}
