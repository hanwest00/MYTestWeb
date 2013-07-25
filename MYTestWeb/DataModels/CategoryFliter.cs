using MYORM.Attributes;

namespace DataModels
{
    public class CategoryFliter : MYORM.MYItemBase, IModels
    {
        [ValueNotNull]
        [Default(0)]
        public int cId
        {
            get;
            set;
        }

        [ValueNotNull]
        [Default(0)]
        public int flId
        {
            get; set;
        }
    }
}
