using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Exceptions
{
    public class ConnectionNullExpection : Exception
    {
        public ConnectionNullExpection()
            : base()
        {

        }

        public ConnectionNullExpection(string message)
            : base(message)
        {

        }
    }
}
