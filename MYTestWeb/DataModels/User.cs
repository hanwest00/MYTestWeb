using MYORM.Attributes;

namespace DataModels
{
    public class User : MYORM.MYItemBase
    {
        [PrimaryKey]
        [Identity(1,1)]
        [ValueNotNull]
        public int id
        { 
            get; 
            set;
        }

        [ValueNotNull]
        public int groupId
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
