using MYORM.Attributes;

namespace DataModels
{
    public class CategoryModel : MYORM.MYItemBase, IModels
    {
        [ValueNotNull]
        [Default(0)]
        public int cid
        {
            get;
            set;
        }

        [ValueNotNull]
        [Default(0)]
        public int mId
        {
            get;
            set;
        }
    }
}
