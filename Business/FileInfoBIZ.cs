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
    public class FileInfoBIZ : IFileInfoBIZ
    {
        public FileInfo GetFileInfoByCIIdAndMId(int ciId, int mId)
        {
            try
            {
                IList<FileInfo> tmp = DataCollection.FileInfoInstance.GetAll(null, new Equal(MYDBLogic.AND, "ciId", ciId.ToString()), new Equal(MYDBLogic.AND, "mId", mId.ToString()));
                if (tmp != null && tmp.Count > 0) return tmp[0];
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<FileInfo> GetFileInfoByCIdAndMId(int cId, int mId, int page, int pageSize)
        {
            try
            {
                return DataCollection.FileInfoInstance.GetAll(null, page, pageSize, new OrderBy("ciId", "asc"), new MYDBQJoin[] { new MYDBQJoin("CategoryInfo", MYDBQJoin.JoinType.INNER, new Equal(MYDBLogic.AND, "CategoryInfo.id", "DateInfo.ciId"), new Equal(MYDBLogic.AND, "CategoryInfo.cId", cId.ToString())) }, new Equal(MYDBLogic.AND, "DateInfo.mId", mId.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddFileInfo(FileInfo fileInfo)
        {
            DataCollection.FileInfoInstance.Insert(fileInfo);
        }

        public void ModifyFileInfo(FileInfo fileInfo)
        {
            DataCollection.FileInfoInstance.Update(fileInfo);
        }

        public void RemoveFileInfo(FileInfo fileInfo)
        {
            DataCollection.FileInfoInstance.Remove(fileInfo);
        }
    }
}
