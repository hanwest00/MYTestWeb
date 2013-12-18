using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels;
using MYORM;

namespace Util.Log
{
    public class LogToDb : ILog
    {
        private static MYORM.Interfaces.ITable<DataModels.Logs> log = MYORM.SqlServer.SqlServerTable<DataModels.Logs>.GetInstance();
        public bool Error(string message)
        {
            return WriteToDb("Error", message);
        }
        public bool Action(string message)
        {
            return WriteToDb("Action", message);
        }
        public bool System(string message)
        {
            return WriteToDb("System", message);
        }
        public bool User(string message)
        {
           return WriteToDb("User", message);
        }

        private bool WriteToDb(string type, string message)
        {
            try
            {
                log.Insert(new DataModels.Logs
                {
                    content = message,
                    logDate = DateTime.Now,
                    logType = type
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
