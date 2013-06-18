using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Log
{
    public class LogIoc
    {
        private static MYIoc.IocContains logContains;

        public static IList<ILog> GetInstance()
        {
            logContains = new MYIoc.IocContains();
            //logContains.RegisterType<ILog, Log>();
            //logContains.RegisterType<ILog, LogToDb>();
            logContains.RegisterTypeFromConfig();
            return logContains.Resolves<ILog>();
        }
    }
}
