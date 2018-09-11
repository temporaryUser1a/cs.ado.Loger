using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLoger
{
    interface IEvent
    {
        void Execute();
    }
}
