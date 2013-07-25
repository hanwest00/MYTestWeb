using System;
using MYORM.Attributes;

namespace DataModels
{
    public class DateInfo : MYORM.MYItemBase, IModels
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
        public int ciId
        {
            get;
            set;
        }

        [ValueNotNull]
        public int mId
        {
            get;
            set;
        }

        public DateTime content
        {
            get;
            set;
        }
    }
}
