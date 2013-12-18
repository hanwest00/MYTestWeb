using System;
using System.Collections.Generic;
using System.Text;

namespace MYORM.Attributes
{
    public class Datebase : Attribute
    {
        private string name;
        public string Name
        {
            get 
            { 
                return name; 
            }

            private set 
            { 
                name = value; 
            }
        }


        public Datebase(string name)
        {
            Name = name;
        }
    }
}
