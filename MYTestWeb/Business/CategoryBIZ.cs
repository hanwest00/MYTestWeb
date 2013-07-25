using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using DataModels;
using IBusiness;

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
            return DataCollection.CategoryInstance.GetAll(null, page, pageSize, new MYORM.Conditions.OrderBy("id", "asc"), null, pId > 0 ? new MYORM.Conditions.Equal(MYORM.Conditions.MYDBLogic.AND, "pId", pId.ToString()) : null);
        }

        public IList<Category> GetPermitCategoryList(int page, int pageSize, int uId)
        {
            return this.GetPermitCategoryList(page, pageSize, uId, 0);
        }

        public IList<Category> GetPermitCategoryList(int page, int pageSize, int uId, int pId)
        {
            return DataCollection.CategoryInstance.GetAll(null, page, pageSize, new MYORM.Conditions.OrderBy("id", "asc"), new MYORM.Conditions.MYDBQJoin[] { new MYORM.Conditions.MYDBQJoin("Privilege", MYORM.Conditions.MYDBQJoin.JoinType.INNER, new MYORM.Conditions.Equal(MYORM.Conditions.MYDBLogic.AND, "Privilege.cId", "Category.id"), new MYORM.Conditions.Equal(MYORM.Conditions.MYDBLogic.AND, "Privilege.uId", uId.ToString())) }, pId > 0 ? new MYORM.Conditions.Equal(MYORM.Conditions.MYDBLogic.AND, "pId", pId.ToString()) : null);
        }

        public void AddCategory(Category cate)
        {
            DataCollection.CategoryInstance.Insert(cate);
        }

        public void ModifyCategory(Category cate)
        {
            DataCollection.CategoryInstance.Update(cate);
        }

        public void RemoveCategory(Category cate)
        {
            DataCollection.CategoryInstance.Remove(cate);
        }
    }
}
