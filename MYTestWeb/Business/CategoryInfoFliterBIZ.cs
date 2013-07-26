using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBusiness;
using DataModels;
using MYORM.Conditions;

namespace Business
{
    public class CategoryInfoFliterBIZ : ICategoryInfoFliterBIZ
    {
        public CategoryInfoFliter GetCategoryInfoFliter(int ciId, int flId)
        {
            try
            {
                IList<CategoryInfoFliter> tmp = DataCollection.CategoryInfoFliterInstance.GetAll(null, new Equal(MYDBLogic.AND, "ciId", ciId.ToString()), new Equal(MYDBLogic.AND, "flId", flId.ToString()));
                if (tmp != null && tmp.Count > 0) return tmp[0];
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddCategoryInfoFliter(CategoryInfoFliter categoryInfoFliter)
        {
            try
            {
                CategoryInfoFliter old = new CategoryInfoFliter { ciId = categoryInfoFliter.ciId, flId = categoryInfoFliter.flId };
                this.RemoveCategoryInfoFliter(old);
                DataCollection.CategoryInfoFliterInstance.Insert(categoryInfoFliter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveCategoryInfoFliter(CategoryInfoFliter categoryInfoFliter)
        {
            DataCollection.CategoryInfoFliterInstance.Remove(categoryInfoFliter);
        }

        public void ModifyCategoryInfoFliter(CategoryInfoFliter categoryInfoFliter)
        {
            DataCollection.CategoryInfoFliterInstance.Update(categoryInfoFliter);
        }
    }
}
