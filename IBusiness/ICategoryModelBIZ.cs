using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface ICategoryModelBIZ
    {
        IList<CategoryModel> GetCategoryModelByCId(int cId);
        void AddCategoryModel(CategoryModel categoryModel);
        void ModifyCategoryModel(CategoryModel categoryModel);
        void RemoveCategoryModel(CategoryModel categoryModel);
        void ChangeOrder(CategoryModel categoryModel1, CategoryModel categoryModel2);
    }
}
