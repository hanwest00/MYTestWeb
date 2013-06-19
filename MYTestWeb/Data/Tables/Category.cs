using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Attributes;

namespace Data.Tables
{
    public class Category : MYORM.MYItemBase
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int Id
        {
            get;
            set;
        }


    }
}
