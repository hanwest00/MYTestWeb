using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBusiness;
using DataModels;
using MYORM.Conditions;
using IBusiness;

namespace Business
{
    public class CategoryInfoBIZ : ICategoryInfoBIZ
    {
        public IList<CategoryInfo> GetCategoryInfoByCId(int cId, int asc)
        {
            return DataCollection.CategoryInfoInstance.GetAll(null, new Equal(MYDBLogic.AND, "cId", cId.ToString()), new OrderBy("order", asc == 0 ? "asc" : "desc"));
        }
        public void AddCategoryInfo(CategoryInfo categoryInfo)
        {
            try
            {
                object maxOrder = DataCollection.CategoryInfoInstance.GetFeildValue("max(order)", new Equal(MYDBLogic.AND, "cId", categoryInfo.cId.ToString()));
                categoryInfo.order = maxOrder != null ? Convert.ToInt32(maxOrder) + 1 : 1;
                DataCollection.CategoryInfoInstance.Insert(categoryInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ModifyCategoryInfo(CategoryInfo categoryInfo)
        {
            DataCollection.CategoryInfoInstance.Update(categoryInfo);
        }
        public void RemoveCategoryInfo(CategoryInfo categoryInfo)
        {
            DataCollection.CategoryInfoInstance.Remove(categoryInfo);
        }
        public void ChangeOrder(CategoryInfo categoryInfo1, CategoryInfo categoryInfo2)
        {
            try
            {
                int tmp = categoryInfo1.order;
                categoryInfo1.order = categoryInfo2.order;
                categoryInfo2.order = tmp;
                DataCollection.CategoryInfoInstance.Update(categoryInfo1);
                DataCollection.CategoryInfoInstance.Update(categoryInfo2);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
