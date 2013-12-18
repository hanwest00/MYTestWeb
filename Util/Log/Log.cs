using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Log
{
    public class Log : ILog
    {
        public bool Error(string message)
        {
            return new Error().Write(message);
        }
        public bool Action(string message)
        {
            return new Action().Write(message);
        }
        public bool System(string message)
        {
            return new System().Write(message);
        }
        public bool User(string message)
        {
            return new User().Write(message);
        }
    }
}
