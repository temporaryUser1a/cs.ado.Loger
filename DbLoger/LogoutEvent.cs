using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoger
{
    public class LogoutEvent : IEvent
    {
        public void Execute()
        {
            var now = DateTime.Now;
            var machName = Environment.MachineName;
            var userName = Environment.UserName;
            var lastRow = DataBaseOperations.GetLastRow(machName, userName);
            var lastDate =  (DateTime)lastRow["event_date"];
            var duration = DateTime.Now - lastDate;
            DataBaseOperations.AddLogData(now, machName, userName, "Logout", duration.Seconds);
        }
    }
}
