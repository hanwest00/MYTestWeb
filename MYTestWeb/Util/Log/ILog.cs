using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Log
{
    public interface ILog
    {
        bool Error(string message);
        bool Action(string message);
        bool System(string message);
        bool User(string message);
    }
}
