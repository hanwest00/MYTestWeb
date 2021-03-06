﻿using MYORM.Attributes;

namespace DataModels
{
    public class Logs : MYORM.MYItemBase, IModels
    {
        [PrimaryKey]
        [Identity(1,1)]
        [ValueNotNull]
        public int id
        {
            get;
            set;
        }

        [ValueNotNull]
        public string logType
        {
            get;
            set;
        }

        [DBValueType("text")]
        public string content
        {
            get;
            set;
        }

        public System.DateTime logDate
        {
            get;
            set;
        }
    }
}
