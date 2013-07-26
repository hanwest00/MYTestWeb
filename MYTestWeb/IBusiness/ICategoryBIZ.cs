using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface ICategoryBIZ
    {
        IList<Category> GetCategoryList(int page, int pageSize);
        IList<Category> GetCategoryList(int page, int pageSize, int pId);
        IList<Category> GetPermitCategoryList(int page, int pageSize, int uId);
        IList<Category> GetPermitCategoryList(int page, int pageSize, int uId, int pId);
        void AddCategory(Category cate);
        void ModifyCategory(Category cate);
        void RemoveCategory(Category cate);
        void ChangeOrder(Category cate1, Category cate2);
    }
}
