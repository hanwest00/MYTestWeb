using System;
using MYORM.Attributes;

namespace DataModels
{
    public class Group : MYORM.Interfaces.MYItemBase, IModels
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int id
        {
            get;
            set;
        }

        [Unique]
        public string name
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
