using System;
using MYORM.Attributes;

namespace DataModels
{
    public class CategoryFliter : MYORM.Interfaces.MYItemBase, IModels
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
