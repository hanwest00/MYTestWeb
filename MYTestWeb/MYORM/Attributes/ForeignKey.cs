using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Attributes
{
    public class ForeignKey : Attribute
    {
        public string TableName
        {
            get;
            private set;
        }

        public string Id
        {
            get;
            private set;
        }

        public ForeignKey(string tableName,string id)
        {
            TableName = tableName;
            Id = id;
        }
    }
}
