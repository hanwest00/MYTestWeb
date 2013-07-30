using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using DataModels;
using IBusiness;
using MYORM.Conditions;

namespace Business
{
    public class CategoryBIZ : ICategoryBIZ
    {
        public IList<Category> GetCategoryList(int page, int pageSize)
        {
            return this.GetCategoryList(page, pageSize, 0);
        }

        public IList<Category> GetCategoryList(int page, int pageSize, int pId)
        {

            return DataCollection.CategoryInstance.GetAll(null, page, pageSize, new OrderBy("id", "asc"), null, pId > 0 ? new Equal(MYDBLogic.AND, "pId", pId.ToString()) : null, new OrderBy("order", "asc"));

        }

        public IList<Category> GetPermitCategoryList(int page, int pageSize, int uId)
        {

            return this.GetPermitCategoryList(page, pageSize, uId, 0);

        }

        public IList<Category> GetPermitCategoryList(int page, int pageSize, int uId, int pId)
        {
            try
            {
                return DataCollection.CategoryInstance.GetAll(null, page, pageSize, new OrderBy("id", "asc"), new MYDBQJoin[] { new MYDBQJoin("Privilege", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "Privilege.cId", "Category.id"), new Equal(MYDBLogic.AND, "Privilege.uId", uId.ToString())) }, pId > 0 ? new Equal(MYDBLogic.AND, "pId", pId.ToString()) : null, new OrderBy("order", "asc"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddCategory(Category cate)
        {
            try
            {
                object maxOrder = DataCollection.CategoryInstance.GetFeildValue("max(order)", new Equal(MYDBLogic.AND, "pId", cate.pId.ToString()));
                cate.order = maxOrder != null ? Convert.ToInt32(maxOrder) + 1 : 1;
                DataCollection.CategoryInstance.Insert(cate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModifyCategory(Category cate)
        {
            DataCollection.CategoryInstance.Update(cate);
        }

        public void RemoveCategory(Category cate)
        {
            DataCollection.CategoryInstance.Remove(cate);
        }

        public void ChangeOrder(Category cate1, Category cate2)
        {
            try
            {
                int tmp = cate1.order;
                cate1.order = cate2.order;
                cate2.order = tmp;
                DataCollection.CategoryInstance.Update(cate1);
                DataCollection.CategoryInstance.Update(cate2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ChildrenCount(int id)
        {
            try
            {
                int ret;
                if (int.TryParse(DataCollection.CategoryInstance.GetFeildValue("count(1)", new Equal(MYDBLogic.AND, "pId", id.ToString())).ToString(), out ret))
                    return ret;
                else
                    return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
