using MYORM.Attributes;

namespace DataModels
{
    public class TextInfo : MYORM.Interfaces.MYItemBase, IModels
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

        [DBValueType("text")]
        public string content
        {
            get;
            set;
        }
    }
}
