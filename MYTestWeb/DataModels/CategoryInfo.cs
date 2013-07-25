using MYORM.Attributes;

namespace DataModels
{
    public class CategoryInfo : MYORM.MYItemBase, IModels
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
        public int cId
        {
            get;
            set;
        }
    }
}
