using MYORM.Attributes;

namespace DataModels
{
    public class Group : MYORM.MYItemBase
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
