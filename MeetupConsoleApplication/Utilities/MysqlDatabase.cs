using System;
using MySql.Data.MySqlClient;

namespace SemihCelek.MeetupConsoleApplication.Utilities
{
    public class MysqlDatabase : IDisposable
    {
        public readonly MySqlConnection MySqlConnection;
        private string connectionString =
            "server=127.0.0.1; database=meetupdb; uid=root; pwd=;";

        public MysqlDatabase()
        {
            try
            {
                MySqlConnection = new MySqlConnection(connectionString);
                MySqlConnection.Open();
                Console.WriteLine("Trying to connect...");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            MySqlConnection.Close();
        }
    }
}