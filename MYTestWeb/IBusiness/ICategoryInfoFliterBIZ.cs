using System;
using DataModels;

namespace IBusiness
{
    public interface ICategoryInfoFliterBIZ
    {
        CategoryInfoFliter GetCategoryInfoFliter(int ciId, int flId);
        void AddCategoryInfoFliter(CategoryInfoFliter categoryInfoFliter);
        void RemoveCategoryInfoFliter(CategoryInfoFliter categoryInfoFliter);
        void ModifyCategoryInfoFliter(CategoryInfoFliter categoryInfoFliter);
    }
}
