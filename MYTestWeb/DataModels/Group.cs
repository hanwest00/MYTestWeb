using MYORM.Attributes;

namespace DataModels
{
    public class Group : MYORM.MYItemBase
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
    }
}
