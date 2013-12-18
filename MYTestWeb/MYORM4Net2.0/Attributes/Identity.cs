using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Attributes
{
    public class Identity : Attribute
    {
        public int Seed
        {
            get;
            private set;
        }

        public int Value
        {
            get;
            private set;
        }

        public Identity(int seed, int value)
        {
            Seed = seed;
            Value = value;
        }
    }
}
