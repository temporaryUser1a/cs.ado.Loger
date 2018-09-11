using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoger
{
    public class UndefinedEvent : IEvent
    {
        public void Execute()
        {
            Console.WriteLine("Undefined command parameter");
        }
    }
}
