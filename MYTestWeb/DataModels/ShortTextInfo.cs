using MYORM.Attributes;

namespace DataModels
{
    public class ShortTextInfo : MYORM.MYItemBase
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

        [DBValueType("nvarchar(255)")]
        public string content
        {
            get;
            set;
        }
    }
}
