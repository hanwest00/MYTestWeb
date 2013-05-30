using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Exceptions
{
    public class CreateDBException : Exception
    {
        public CreateDBException()
            : base()
        {

        }

        public CreateDBException(string message)
            : base(message)
        {

        }
    }
}
