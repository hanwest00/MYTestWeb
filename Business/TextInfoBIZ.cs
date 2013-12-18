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
    public class TextInfoBIZ : ITextInfoBIZ
    {
        public TextInfo GetTextInfoByCIIdAndMId(int ciId, int mId)
        {
            try
            {
                IList<TextInfo> tmp = DataCollection.TextInfoInstance.GetAll(null, new Equal(MYDBLogic.AND, "ciId", ciId.ToString()), new Equal(MYDBLogic.AND, "mId", mId.ToString()));
                if (tmp != null && tmp.Count > 0) return tmp[0];
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<TextInfo> GetTextInfoByCIdAndMId(int cId, int mId, int page, int pageSize)
        {
            try
            {
                return DataCollection.TextInfoInstance.GetAll(null, page, pageSize, new OrderBy("ciId", "asc"), new MYDBQJoin[] { new MYDBQJoin("CategoryInfo", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryInfo.id", "DateInfo.ciId"), new Equal(MYDBLogic.AND, "CategoryInfo.cId", cId.ToString())) }, new Equal(MYDBLogic.AND, "DateInfo.mId", mId.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddTextInfo(TextInfo textInfo)
        {
            DataCollection.TextInfoInstance.Insert(textInfo);
        }

        public void ModifyTextInfo(TextInfo textInfo)
        {
            DataCollection.TextInfoInstance.Update(textInfo);
        }

        public void RemoveTextInfo(TextInfo textInfo)
        {
            DataCollection.TextInfoInstance.Remove(textInfo);
        }
    }
}
