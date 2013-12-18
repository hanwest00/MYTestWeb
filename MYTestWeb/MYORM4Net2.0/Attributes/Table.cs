using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Attributes
{
    public class Table : Attribute
    {
        public string Name
        {
            get;
            private set;
        }

        public Table(string name)
        {
            Name = name;
        }
    }
}
