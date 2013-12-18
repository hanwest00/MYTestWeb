using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface IShortTextInfoBIZ
    {
        ShortTextInfo GetShortTextInfoByCIIdAndMId(int ciId, int mId);
        IList<ShortTextInfo> GetShortTextInfoByCIdAndMId(int cId, int mId, int page, int pageSize);
        void AddShortTextInfo(ShortTextInfo ShortTextInfo);
        void ModifyShortTextInfo(ShortTextInfo ShortTextInfo);
        void RemoveShortTextInfo(ShortTextInfo ShortTextInfo);
    }
}
