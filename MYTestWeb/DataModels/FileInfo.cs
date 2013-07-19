using MYORM.Attributes;

namespace DataModels
{
    public class FileInfo : MYORM.MYItemBase, IModels
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int iId
        {
            get;
            set;
        }

        [ValueNotNull]
        public int mId
        {
            get;
            set;
        }

        [DBValueType("nvarchar(127)")]
        public string url
        {
            get;
            set;
        }

        [DBValueType("nvarchar(127)")]
        public string fileName
        {
            get;
            set;
        }
    }
}
