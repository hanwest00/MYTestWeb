using MYORM.Attributes;

namespace DataModels
{
    public class ImageInfo : MYORM.Interfaces.MYItemBase, IModels
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
