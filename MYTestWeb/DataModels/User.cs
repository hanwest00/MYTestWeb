using MYORM.Attributes;

namespace DataModels
{
    public class User : MYORM.MYItemBase
    {
        [PrimaryKey]
        [Identity(1,1)]
        [ValueNotNull]
        public int Id
        { 
            get; 
            set;
        }

        [ValueNotNull]
        public int GroupId
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
