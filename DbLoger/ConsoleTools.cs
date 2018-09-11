using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DbLoger
{
    public static class ConsoleTools
    {
        private static readonly int defaultWidth = 20;

        public static void DisplayTable(DataTable dataTable)
        {
            var fldCnt = dataTable.Columns.Count;
            var smb = '|';
            DisplayString(new string('-', defaultWidth * fldCnt), defaultWidth * fldCnt, '+', '+');
            for (int i = 0; i < fldCnt; ++i)
            {
                DisplayString(dataTable.Columns[i].ColumnName, defaultWidth, smb, '|');
                smb = ' ';
            }
            DisplayString(new string('-', defaultWidth * fldCnt), defaultWidth * fldCnt, '+', '+');
            for (int i = 0; i < dataTable.Rows.Count; ++i)
            {
                smb = '|';
                for (int j = 0; j < fldCnt; ++j)
                {
                    DisplayString(dataTable.Rows[i][j].ToString(), defaultWidth, smb, '|');
                    smb = ' ';
                }
            }
            DisplayString(new string('-', defaultWidth * fldCnt), defaultWidth * fldCnt, '+', '+');
        }

        public static void DisplayString(string str, int width, 
            char begin = ' ', char end = ' ')
        {
            if (begin != ' ')
            {
                Console.Write(begin);
                --width;
            }
            for (int i = 0; i < width - 1; ++i)
            {
                if (i < str.Length)
                    Console.Write(str[i]);
                else
                    Console.Write(' ');
            }
            Console.Write(end);
        }
    }
}
