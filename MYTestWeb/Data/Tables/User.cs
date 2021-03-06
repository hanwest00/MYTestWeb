﻿using MYORM;
using MYORM.Attributes;

namespace Data.Tables
{
    public class User : MYItemBase
    {
        [PrimaryKey]
        [Identity(1,1)]
        [ValueNotNull]
        public int Id
        { 
            get; 
            set;
        }

        [ValueNotNull]
        public int GroupId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }


    }
}
