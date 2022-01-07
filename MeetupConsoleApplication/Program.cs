using SemihCelek.MeetupConsoleApplication.Controller;
using SemihCelek.MeetupConsoleApplication.Services.MeetupService;
using SemihCelek.MeetupConsoleApplication.Services.UserService;
using SemihCelek.MeetupConsoleApplication.Utilities;

namespace SemihCelek.MeetupConsoleApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var sqlConnection = new MysqlDatabase();
            
            var userService = new UserService(new MysqlUserAccess(sqlConnection.MySqlConnection));
            var meetupService = new MeetupService(new MysqlMeetupAccess(sqlConnection.MySqlConnection));

            var commandLine = new CommandLineController(meetupService, userService);
            commandLine.InitializeCommandLine();
        }
    }
}