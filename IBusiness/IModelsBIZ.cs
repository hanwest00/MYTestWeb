using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface IModelsBIZ
    {
        IList<Models> GetModels(int page, int pageSize);

        int GetCount();

        IList<Models> GetModelsByCId(int cId);

        int GetCountByCId(int cId);

        void AddModels(Models model);

        void RemoveModels(Models model);

        void ModifyModels(Models model);

        void ModifyModelsById(Models model, string id);

        void ModifyModelsBycId(Models model, string cId);
    }
}
