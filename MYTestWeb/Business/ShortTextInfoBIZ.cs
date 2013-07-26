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
    public class ShortTextInfoBIZ : IShortTextInfoBIZ
    {
        public ShortTextInfo GetShortTextInfoByCIIdAndMId(int ciId, int mId)
        {
            try
            {
                IList<ShortTextInfo> tmp = DataCollection.ShortTextInfoInstance.GetAll(null, new Equal(MYDBLogic.AND, "ciId", ciId.ToString()), new Equal(MYDBLogic.AND, "mId", mId.ToString()));
                if (tmp != null && tmp.Count > 0) return tmp[0];
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<ShortTextInfo> GetShortTextInfoByCIdAndMId(int cId, int mId, int page, int pageSize)
        {
            try
            {
                return DataCollection.ShortTextInfoInstance.GetAll(null, page, pageSize, new OrderBy("ciId", "asc"), new MYDBQJoin[] { new MYDBQJoin("CategoryInfo", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryInfo.id", "DateInfo.ciId"), new Equal(MYDBLogic.AND, "CategoryInfo.cId", cId.ToString())) }, new Equal(MYDBLogic.AND, "DateInfo.mId", mId.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddShortTextInfo(ShortTextInfo shortTextInfo)
        {
            DataCollection.ShortTextInfoInstance.Insert(shortTextInfo);
        }

        public void ModifyShortTextInfo(ShortTextInfo shortTextInfo)
        {
            DataCollection.ShortTextInfoInstance.Update(shortTextInfo);
        }

        public void RemoveShortTextInfo(ShortTextInfo shortTextInfo)
        {
            DataCollection.ShortTextInfoInstance.Remove(shortTextInfo);
        }
    }
}
