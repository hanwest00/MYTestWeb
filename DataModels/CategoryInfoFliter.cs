using MYORM.Attributes;

namespace DataModels
{
    public class CategoryInfoFliter : MYORM.MYItemBase, IModels
    {
        [ValueNotNull]
        [Default(0)]
        public int ciId
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

        public int fValue
        {
            get;
            set;
        }
    }
}
