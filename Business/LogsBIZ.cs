using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using DataModels;
using IBusiness;
using MYORM.Conditions;

namespace Business
{
    public class LogsBIZ : ILogsBIZ
    {
        public IList<Logs> GetLogsByDate(DateTime date)
        {
            return DataCollection.LogsInstance.GetAll(null, new Between(MYDBLogic.AND, "logDate", string.Format("'{0}' 00:00:00", date.ToString("yyyy/MM/dd")), string.Format("'{0}' 23:59:59", date.ToString("yyyy/MM/dd"))));
        }

        public IList<Logs> GetLogsBetweenDate(DateTime minDate, DateTime maxDate)
        {
            return DataCollection.LogsInstance.GetAll(null, new MoreEqual(MYDBLogic.AND, "logDate", string.Format("'{0}' 00:00:00", minDate.ToString("yyyy/MM/dd"))), new LessEqual(MYDBLogic.AND, "logDate", string.Format("'{0}' 23:59:59", maxDate.ToString("yyyy/MM/dd"))));
        }

        public void AddLogs(Logs log)
        {
            DataCollection.LogsInstance.Insert(log);
        }

        public void RemoveLogs(Logs log)
        {
            DataCollection.LogsInstance.Remove(log);
        }

        public void ModifyLogs(Logs log)
        {
            DataCollection.LogsInstance.Update(log);
        }
    }
}
