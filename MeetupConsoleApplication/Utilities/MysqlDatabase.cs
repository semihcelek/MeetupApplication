using System;
using MySql.Data.MySqlClient;

namespace SemihCelekBarisKilic.MeetupConsoleApplication.Utilities
{
    public class MysqlDatabase : IDisposable
    {
        public MySqlConnection MySqlConnection;
        private string connectionString =
            "server=127.0.0.1; database=meetupdb; uid=root; pwd=;";

        public MysqlDatabase()
        {
            try
            {
                this.MySqlConnection = new MySqlConnection(connectionString);
                this.MySqlConnection.Open();
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