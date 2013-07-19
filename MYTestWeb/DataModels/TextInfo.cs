using MYORM.Attributes;

namespace DataModels
{
    public class TextInfo : MYORM.MYItemBase, IModels
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

        [DBValueType("text")]
        public string content
        {
            get;
            set;
        }
    }
}
