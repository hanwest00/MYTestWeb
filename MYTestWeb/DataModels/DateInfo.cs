using System;
using MYORM.Attributes;

namespace DataModels
{
    public class DateInfo : MYORM.MYItemBase
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int iId
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
