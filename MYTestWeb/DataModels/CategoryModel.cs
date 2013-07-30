using System;
using MYORM.Attributes;

namespace DataModels
{
    public class CategoryModel : MYORM.Interfaces.MYItemBase, IModels
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
        public int mId
        {
            get;
            set;
        }

        public int order
        {
            get;
            set;
        }

        public DateTime createDate
        {
            get;
            set;
        }
    }
}
