using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYORM.Exceptions
{
    public class TableContianException : Exception
    {
        public TableContianException()
            : base()
        {

        }

        public TableContianException(string message)
            : base(message)
        {

        }
    }
}
