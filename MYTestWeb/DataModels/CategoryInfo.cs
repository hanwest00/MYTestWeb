using System;
using MYORM.Attributes;

namespace DataModels
{
    public class CategoryInfo : MYORM.Interfaces.MYItemBase, IModels
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
