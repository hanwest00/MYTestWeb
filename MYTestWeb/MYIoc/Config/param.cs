using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYIoc.Config
{
    public class param
    {
        public System.Type Type
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string value
        {
            get;
            set;
        }

        public string dependon
        {
            get;
            set;
        }
    }
}
