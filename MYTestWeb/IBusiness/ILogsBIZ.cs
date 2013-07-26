using System;
using System.Collections.Generic;
using DataModels;

namespace IBusiness
{
    public interface ILogsBIZ
    {
        IList<Logs> GetLogsByDate(DateTime date);
        IList<Logs> GetLogsBetweenDate(DateTime minDate, DateTime maxDate);
        void AddLogs(Logs log);
        void RemoveLogs(Logs log);
        void ModifyLogs(Logs log);
    }
}
