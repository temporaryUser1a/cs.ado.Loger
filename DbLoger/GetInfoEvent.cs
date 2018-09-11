using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoger
{
    public class GetInfoEvent : IEvent
    {
        private DateTime from;
        private DateTime to;
        private bool isDefault;

        public GetInfoEvent()
        {
            isDefault = true;
        }
        
        public GetInfoEvent(DateTime from, DateTime to)
        {
            isDefault = false;
            this.from = from;
            this.to = to;
        }

        public void Execute()
        {
            DateTime now;
            DateTime yesterday;
            if (isDefault)
            {
                now = DateTime.Now;
                yesterday = new DateTime(now.Year, now.Month, now.Day - 1);
            }
            else
            {
                now = to;
                yesterday = from;
            }
            var dt = DataBaseOperations.GetLogData(yesterday, now);
            ConsoleTools.DisplayTable(dt);
        }
    }
}
