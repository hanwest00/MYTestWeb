using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Log
{
    public class LogFactory : ILogFactory
    {
        public ILog CreateLog()
        {
            return new Log();
        }

        public ILog CreateDbLog()
        {
            return new LogToDb();
        }
    }
}
