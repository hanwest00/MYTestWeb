using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface IFileInfoBIZ
    {
        FileInfo GetFileInfoByCIIdAndMId(int ciId, int mId);
        IList<FileInfo> GetFileInfoByCIdAndMId(int cId, int mId, int page, int pageSize);
        void AddFileInfo(FileInfo fileInfo);
        void ModifyFileInfo(FileInfo fileInfo);
        void RemoveFileInfo(FileInfo fileInfo);
    }
}
