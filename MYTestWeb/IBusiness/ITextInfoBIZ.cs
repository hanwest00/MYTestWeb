using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface ITextInfoBIZ
    {
        TextInfo GetTextInfoByCIIdAndMId(int ciId, int mId);
        IList<TextInfo> GetTextInfoByCIdAndMId(int cId, int mId, int page, int pageSize);
        void AddTextInfo(TextInfo TextInfo);
        void ModifyTextInfo(TextInfo TextInfo);
        void RemoveTextInfo(TextInfo TextInfo);
    }
}
