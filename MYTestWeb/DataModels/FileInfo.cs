using MYORM.Attributes;

namespace DataModels
{
    public class FileInfo : MYORM.Interfaces.MYItemBase, IModels
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int id
        {
            get;
            set;
        }

        [ValueNotNull]
        public int ciId
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
