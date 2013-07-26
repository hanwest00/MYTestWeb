using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface IDateInfoBIZ
    {
        DateInfo GetDateInfoByCIIdAndMId(int ciId, int mId);
        IList<DateInfo> GetDateInfoByCIdAndMId(int cId, int mId, int page, int pageSize); 
        void AddDateInfo(DateInfo dateInfo); 
        void ModifyDateInfo(DateInfo dateInfo); 
        void RemoveDateInfo(DateInfo dateInfo);
    }
}
