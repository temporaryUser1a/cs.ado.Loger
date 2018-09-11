using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoger
{
    public class LoginEvent : IEvent
    {
        public void Execute()
        {
            var now = DateTime.Now;
            var machName = Environment.MachineName;
            var userName = Environment.UserName;
            DataBaseOperations.AddLogData(now, machName, userName, "Logout", null);
        }
    }
}
