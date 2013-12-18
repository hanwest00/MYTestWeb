using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Log
{
    public interface ILogFactory
    {
        ILog CreateLog();
        ILog CreateDbLog();
    }
}
