using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Conditions;
using DataModels;

namespace Business
{
    public class FliterBIZ
    {
        public IList<Fliter> GetFliterList(int page, int pageSize)
        {
            return DataCollection.FliterInstance.GetAll(null, page, pageSize, new OrderBy("id", "asc"), null);
        }

        public IList<Fliter> GetFliterByCId(int cId)
        {
            try
            {
                return DataCollection.FliterInstance.GetAll(null, 0, 0, null, new MYDBQJoin[] { new MYDBQJoin("CategoryFliter", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryFliter.fId", "Fliter.id"), new Equal(MYDBLogic.AND, "CategoryFliter.cId", cId.ToString())) }, new OrderBy("Fliter.order", "asc"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddModels(Fliter fliter)
        {
            DataCollection.FliterInstance.Insert(fliter);
        }

        public void RemoveModels(Fliter fliter)
        {
            DataCollection.FliterInstance.Remove(fliter);
        }

        public void ModifyModels(Fliter fliter)
        {
            DataCollection.FliterInstance.Update(fliter);
        }
    }
}
