using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels;
using MYORM.SqlServer;
using MYORM;
using MYORM.Interfaces;
using MYORM.Conditions;

namespace Data
{
    public class CategoryDAL
    {
        private static ITable<Category> cate = DataIoc<Category>.GetData();

        public void Insert(Category item)
        {
            cate.Insert(item);
        }

        public void Remove(Category item)
        {
            cate.Delete(item);
        }

        public void Remove(string cateName)
        {
            IList<MYDBCondition> conds = new List<MYDBCondition>();
            conds.Add(new Equal(MYDBLogic.NOTSET, "cateName", cateName));
            cate.Delete(conds);
        }

        public IList<Category> GetAll()
        {
            cate.Where(new List<MYDBCondition>() {
                 new Equal(MYDBLogic.NOTSET,"Id","@Id")
            }, new System.Data.SqlClient.SqlParameter[] { 
                new System.Data.SqlClient.SqlParameter("@Id", "12") 
            });

            return cate.Select("Id", "pId", "cateName");
        }
    }
}
