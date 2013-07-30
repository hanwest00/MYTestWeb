using System;
using MYORM.Attributes;

namespace DataModels
{
    public class Category : MYORM.Interfaces.MYItemBase, IModels
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
        public int pId
        {
            get;
            set;
        }

        public string cateName
        {
            get;
            set;
        }

        public string image
        {
            get;
            set;
        }

        [DBValueType("text")]
        public string description
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
