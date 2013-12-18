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
    public class ImageInfoBIZ : IImageInfoBIZ
    {
        public ImageInfo GetImageInfoByCIIdAndMId(int ciId, int mId)
        {
            try
            {
                IList<ImageInfo> tmp = DataCollection.ImageInfoInstance.GetAll(null, new Equal(MYDBLogic.AND, "ciId", ciId.ToString()), new Equal(MYDBLogic.AND, "mId", mId.ToString()));
                if (tmp != null && tmp.Count > 0) return tmp[0];
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<ImageInfo> GetImageInfoByCIdAndMId(int cId, int mId, int page, int pageSize)
        {
            try
            {
                return DataCollection.ImageInfoInstance.GetAll(null, page, pageSize, new OrderBy("ciId", "asc"), new MYDBQJoin[] { new MYDBQJoin("CategoryInfo", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryInfo.id", "DateInfo.ciId"), new Equal(MYDBLogic.AND, "CategoryInfo.cId", cId.ToString())) }, new Equal(MYDBLogic.AND, "DateInfo.mId", mId.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddImageInfo(ImageInfo imageInfo)
        {
            DataCollection.ImageInfoInstance.Insert(imageInfo);
        }

        public void ModifyImageInfo(ImageInfo imageInfo)
        {
            DataCollection.ImageInfoInstance.Update(imageInfo);
        }

        public void RemoveImageInfo(ImageInfo imageInfo)
        {
            DataCollection.ImageInfoInstance.Remove(imageInfo);
        }
    }
}
