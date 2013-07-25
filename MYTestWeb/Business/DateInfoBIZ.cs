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
        public DateInfo GetDateInfoByciIdAndmId(int ciId, int mId)
        {
            return DataCollection.DateInfoInstance.GetAll(null, new Equal(MYDBLogic.AND, "ciId", ciId.ToString()), new Equal(MYDBLogic.AND, "mId", mId.ToString()))[0];
        }

        public IList<DateInfo> GetDateInfoBycIdAndmId(int cId, int mId, int page, int pageSize)
        {
            return DataCollection.DateInfoInstance.GetAll(null, page, pageSize, new OrderBy("ciId", "asc"), new MYDBQJoin[] { new MYDBQJoin("CategoryInfo", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryInfo.id", "DateInfo.ciId"), new Equal(MYDBLogic.AND, "CategoryInfo.cId", cId.ToString())) }, new Equal(MYDBLogic.AND, "DateInfo.mId", mId.ToString()));
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
