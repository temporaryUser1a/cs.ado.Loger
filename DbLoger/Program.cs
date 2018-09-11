using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DbLoger
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IEvent operation = null;
            if (args.Length == 0)
                operation = new GetInfoEvent();
            else if (String.Compare(args[0], "login", true) == 0)
                operation = new LoginEvent();
            else if (String.Compare(args[0], "logout", true) == 0)
                operation = new LogoutEvent();
            else if (args.Length == 2)
                operation = new GetInfoEvent(Convert.ToDateTime(args[0]), Convert.ToDateTime(args[1]));
            else
                operation = new UndefinedEvent();
            operation.Execute();
        }
    }
}
