using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface IImageInfoBIZ
    {
        ImageInfo GetImageInfoByCIIdAndMId(int ciId, int mId);
        IList<ImageInfo> GetImageInfoByCIdAndMId(int cId, int mId, int page, int pageSize);
        void AddImageInfo(ImageInfo ImageInfo);
        void ModifyImageInfo(ImageInfo ImageInfo);
        void RemoveImageInfo(ImageInfo ImageInfo);
    }
}
