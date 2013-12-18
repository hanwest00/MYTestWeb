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
    public class DateInfoBIZ : IDateInfoBIZ
    {
        public DateInfo GetDateInfoByCIIdAndMId(int ciId, int mId)
        {
            try
            {
                IList<DateInfo> tmp = DataCollection.DateInfoInstance.GetAll(null, new Equal(MYDBLogic.AND, "ciId", ciId.ToString()), new Equal(MYDBLogic.AND, "mId", mId.ToString()));
                if (tmp != null && tmp.Count > 0) return tmp[0];
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<DateInfo> GetDateInfoByCIdAndMId(int cId, int mId, int page, int pageSize)
        {
            try
            {
                return DataCollection.DateInfoInstance.GetAll(null, page, pageSize, new OrderBy("ciId", "asc"), new MYDBQJoin[] { new MYDBQJoin("CategoryInfo", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryInfo.id", "DateInfo.ciId"), new Equal(MYDBLogic.AND, "CategoryInfo.cId", cId.ToString())) }, new Equal(MYDBLogic.AND, "DateInfo.mId", mId.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddDateInfo(DateInfo dateInfo)
        {
            DataCollection.DateInfoInstance.Insert(dateInfo);
        }

        public void ModifyDateInfo(DateInfo dateInfo)
        {
            DataCollection.DateInfoInstance.Update(dateInfo);
        }

        public void RemoveDateInfo(DateInfo dateInfo)
        {
            DataCollection.DateInfoInstance.Remove(dateInfo);
        }
    }
}
