using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoger
{
    public class GetInfoEvent : IEvent
    {
        private DateTime startPoint;
        private DateTime endPoint;
        private bool defaultTime;
        
        public GetInfoEvent()
        {
            defaultTime = true;
        }

        public GetInfoEvent(DateTime start, DateTime end)
        {
            defaultTime = false;
            startPoint = start;
            endPoint = end;
        }

        public void Execute()
        {

        }
    }
}
