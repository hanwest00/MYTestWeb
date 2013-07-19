using MYORM.Attributes;

namespace DataModels
{
    public class Category : MYORM.MYItemBase, IModels
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
        [Default(0)]
        public int pId
        {
            get;
            set;
        }

        public string cateName
        {
            get;
            set;
        }
    }
}
