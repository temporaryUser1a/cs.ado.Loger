using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DbLoger
{
    public static class DataBaseOperations
    {
        private static readonly string connectionString = @"Data Source=DESKTOP-PC73D7E\SQLEXPRESS;Initial Catalog=Loger;Integrated Security=True";

        public static void AddLogData(DateTime dt, string machName,
            string userName, string eventType, int? duration)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Main.AddToInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@event_type", eventType);
                command.Parameters.AddWithValue("@event_date", dt);
                command.Parameters.AddWithValue("@machine_name", machName);
                command.Parameters.AddWithValue("@user_name", userName);
                if (duration == null)
                    command.Parameters.AddWithValue("@duration", DBNull.Value);
                else
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

        public static DataTable GetLogData(DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Main.Info WHERE event_date BETWEEN @from AND @to", connection);
                command.Parameters.Add("@from", SqlDbType.DateTime).Value = from;
                command.Parameters.Add("@to", SqlDbType.DateTime).Value = to;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
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
            return dt;
        }
    }
}
