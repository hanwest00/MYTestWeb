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
    public class ModelsBIZ : IModelsBIZ
    {
        public IList<Models> GetModels(int page, int pageSize)
        {
            return DataCollection.ModelsInstance.GetAll(null, page, pageSize, new OrderBy("id", "asc"), null);
        }

        public int GetCount()
        {
            return Convert.ToInt32(DataCollection.ModelsInstance.GetFeildValue("count(1)"));
        }

        public IList<Models> GetModelsByCId(int cId)
        {
            try
            {
                return DataCollection.ModelsInstance.GetAll(null, 0, 0, null, new MYDBQJoin[] { new MYDBQJoin("CategoryModel", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryModel.mId", "Models.id"), new Equal(MYDBLogic.AND, "CategoryModel.cId", cId.ToString())) }, new OrderBy("CategoryModel.order", "asc"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetCountByCId(int cId)
        {
            return Convert.ToInt32(DataCollection.ModelsInstance.GetFeildValue("count(1)", new MYDBQJoin[] { new MYDBQJoin("CategoryModel", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryModel.mId", "Models.id"), new Equal(MYDBLogic.AND, "CategoryModel.cId", cId.ToString())) }));
        }

        public void AddModels(Models model)
        {
            DataCollection.ModelsInstance.Insert(model);
        }

        public void RemoveModels(Models model)
        {
            DataCollection.ModelsInstance.Remove(model);
        }

        public void ModifyModels(Models model)
        {
            DataCollection.ModelsInstance.Update(model);
        }

        public void ModifyModelsById(Models model, string id)
        {
            DataCollection.ModelsInstance.Update(model, new List<MYDBCondition> { new MYORM.Conditions.Equal(MYDBLogic.AND, "id", id) });
        }

        public void ModifyModelsBycId(Models model, string cId)
        {
            DataCollection.ModelsInstance.Update(model, new List<MYDBCondition> { new MYORM.Conditions.Equal(MYDBLogic.AND, "cId", cId) });
        }
    }
}
