using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Attributes
{
    public class Default : Attribute
    {
        public object Value
        {
            get;
            private set;
        }

        public Default(object value)
        {
            Value = value;
        }
    }
}
