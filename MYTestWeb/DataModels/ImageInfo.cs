using MYORM.Attributes;

namespace DataModels
{
    public class ImageInfo : MYORM.MYItemBase
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

        public byte[] content
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

        /// <summary>
        /// 0:image/jpeg
        /// 1:image/png
        /// 2:image/gif
        /// </summary>
        public int contentType
        {
            get;
            set;
        }
    }
}
