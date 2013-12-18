using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels;
using MYORM.Conditions;
using IBusiness;

namespace Business
{
    public class CategoryFliterBIZ : ICategoryFliterBIZ
    {
        public IList<CategoryFliter> GetCategoryFliterByCId(int cId)
        {
            return DataCollection.CategoryFliterInstance.GetAll(null, new Equal(MYDBLogic.AND, "cId", cId.ToString()), new OrderBy("order", "asc"));
        }

        public void AddCategoryFliter(CategoryFliter CategoryFliter)
        {
            try
            {
                object maxOrder = DataCollection.CategoryFliterInstance.GetFeildValue("max(order)", new Equal(MYDBLogic.AND, "cId", CategoryFliter.cId.ToString()));
                CategoryFliter.order = maxOrder != null ? Convert.ToInt32(maxOrder) + 1 : 1;
                DataCollection.CategoryFliterInstance.Insert(CategoryFliter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModifyCategoryFliter(CategoryFliter CategoryFliter)
        {
            DataCollection.CategoryFliterInstance.Update(CategoryFliter);
        }

        public void RemoveCategoryFliter(CategoryFliter CategoryFliter)
        {
            DataCollection.CategoryFliterInstance.Remove(CategoryFliter);
        }

        public void ChangeOrder(CategoryFliter categoryFliter1, CategoryFliter categoryFliter2)
        {
            try
            {
                int tmp = categoryFliter1.order;
                categoryFliter1.order = categoryFliter2.order;
                categoryFliter2.order = tmp;
                DataCollection.CategoryFliterInstance.Update(categoryFliter1);
                DataCollection.CategoryFliterInstance.Update(categoryFliter2);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
