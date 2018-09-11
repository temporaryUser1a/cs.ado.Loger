using System;
using System.Data;
using System.Data.OleDb;

namespace DbLoger
{
    public static class DataBaseOperations
    {
        public static void AddLogData(DateTime dt, string machName,
            string userName, string eventType, int? duration)
        {
            string connectionString = @"Data Source=DESKTOP-PC73D7E\MSSQLSERVER1;Initial Catalog=Loger;Integrated Security=True";
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("Main.AddToInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@event_type", eventType);
                command.Parameters.AddWithValue("@event_date", dt);
                command.Parameters.AddWithValue("@machine_name", machName);
                command.Parameters.AddWithValue("@user_name", userName);
                command.Parameters.AddWithValue("@duration", duration);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        // last 24 hours
        public static DataTable GetLogData()
        {
            string connectionString = @"Data Source=DESKTOP-PC73D7E\MSSQLSERVER1;Initial Catalog=Loger;Integrated Security=True";
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Main.AddToInfo WHERE event_date BETWEEN DATEADD(day, -1, GETDATE()) AND GETDATE()", connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return null;
        }
    }
}
