using System;
using MYORM.Attributes;

namespace DataModels
{
    public class Fliter : MYORM.Interfaces.MYItemBase, IModels
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int id
        {
            get;
            set;
        }

        [DBValueType("nvarchar(127)")]
        public string fName
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
