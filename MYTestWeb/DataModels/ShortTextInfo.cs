using MYORM.Attributes;

namespace DataModels
{
    public class ShortTextInfo : MYORM.MYItemBase, IModels
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

        [DBValueType("nvarchar(255)")]
        public string content
        {
            get;
            set;
        }
    }
}
