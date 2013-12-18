using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Attributes
{
    public class DBValueType : Attribute
    {
        public string ValueType
        {
            get;
            private set;
        }

        public DBValueType(string valueType)
        {
            ValueType = valueType;
        }
    }
}
