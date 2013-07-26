using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface IModelsBIZ
    {
        IList<Models> GetModels(int page, int pageSize);

        IList<Models> GetModelsByCId(int cId);

        void AddModels(Models model);

        void RemoveModels(Models model);

        void ModifyModels(Models model);
    }
}
