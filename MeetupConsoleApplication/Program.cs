using SemihCelekBarisKilic.MeetupConsoleApplication.Services.UserService;
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

            // var ahmet = new UserModel("Ahmet", "Sanki", "ahmet@mail.com", "secret", "546231321");
            // userService.CreateUser(ahmet);
            userService.DeleteUser(3);
            userService.GetAllUsers();


            var commandLine = new CommandLineController();
            commandLine.InitCommandLine();
        }
    }
}