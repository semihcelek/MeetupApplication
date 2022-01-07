using SemihCelekBarisKilic.MeetupConsoleApplication.Services;
using SemihCelekBarisKilic.MeetupConsoleApplication.Utilities;

namespace SemihCelekBarisKilic.MeetupConsoleApplication
{
    class Program
    {
        private static void Main(string[] args)
        {
            var sqlConnection = new MysqlDatabase();
            var userService = new UserService(new MysqlUserAccess(sqlConnection.MySqlConnection));

            userService.GetAllUsers();
            userService.FindOne(1);

            var commandLine = new CommandLineController();
            commandLine.InitCommandLine();
        }
    }
}