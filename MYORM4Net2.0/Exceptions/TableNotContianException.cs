using System;
using System.Collections.Generic;

using System.Text;

namespace MYORM.Exceptions
{
    public class TableNotContianException : Exception
    {
         public TableNotContianException()
            : base()
        {

        }

         public TableNotContianException(string message)
            : base(message)
        {

        }
    }
}
