using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels;
using MYORM.Conditions;
using IBusiness;

namespace Business
{
    public class CategoryModelBIZ : ICategoryModelBIZ
    {
        public IList<CategoryModel> GetCategoryModelByCId(int cId)
        {
            return DataCollection.CategoryModelInstance.GetAll(null, new Equal(MYDBLogic.AND, "cId", cId.ToString()), new OrderBy("order", "asc"));
        }

        public void AddCategoryModel(CategoryModel categoryModel)
        {
            try
            {
                object maxOrder = DataCollection.CategoryModelInstance.GetFeildValue("max(order)", new Equal(MYDBLogic.AND, "cId", categoryModel.cId.ToString()));
                categoryModel.order = maxOrder != null ? Convert.ToInt32(maxOrder) + 1 : 1;
                DataCollection.CategoryModelInstance.Insert(categoryModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModifyCategoryModel(CategoryModel categoryModel)
        {
            DataCollection.CategoryModelInstance.Update(categoryModel);
        }

        public void RemoveCategoryModel(CategoryModel categoryModel)
        {
            DataCollection.CategoryModelInstance.Remove(categoryModel);
        }

        public void ChangeOrder(CategoryModel categoryModel1, CategoryModel categoryModel2)
        {
            try
            {
                int tmp = categoryModel1.order;
                categoryModel1.order = categoryModel2.order;
                categoryModel2.order = tmp;
                DataCollection.CategoryModelInstance.Update(categoryModel1);
                DataCollection.CategoryModelInstance.Update(categoryModel2);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
