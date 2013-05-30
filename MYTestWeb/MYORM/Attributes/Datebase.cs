using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Attributes
{
    public class Datebase : Attribute
    {
        public string Name
        {
            get;
            private set;
        }

        public Datebase(string name)
        {
            Name = name;
        }
    }
}
