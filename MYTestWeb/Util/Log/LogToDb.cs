using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using MYORM;

namespace Util.Log
{
    public class LogToDb : ILog
    {
        private static MYORM.Interfaces.ITable<Data.Tables.Logs> log = MYORM.SqlServer.SqlServerTable<Data.Tables.Logs>.GetInstance();
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
                log.Insert(new Data.Tables.Logs
                {
                    Content = message,
                    LogDate = DateTime.Now,
                    LogType = type
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
