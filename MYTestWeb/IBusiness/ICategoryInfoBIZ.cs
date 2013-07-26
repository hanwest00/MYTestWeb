using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface ICategoryInfoBIZ
    {
        IList<CategoryInfo> GetCategoryInfoByCId(int cId, int asc);
        void AddCategoryInfo(CategoryInfo categoryInfo);
        void ModifyCategoryInfo(CategoryInfo categoryInfo);
        void RemoveCategoryInfo(CategoryInfo categoryInfo);
        void ChangeOrder(CategoryInfo categoryInfo1, CategoryInfo categoryInfo2);
    }
}
