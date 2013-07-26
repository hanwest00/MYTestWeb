using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface ICategoryFliterBIZ
    {
        IList<CategoryFliter> GetCategoryFliterByCId(int cId);
        void AddCategoryFliter(CategoryFliter CategoryFliter);
        void ModifyCategoryFliter(CategoryFliter CategoryFliter);
        void RemoveCategoryFliter(CategoryFliter CategoryFliter);
        void ChangeOrder(CategoryFliter categoryFliter1, CategoryFliter categoryFliter2);
    }
}
