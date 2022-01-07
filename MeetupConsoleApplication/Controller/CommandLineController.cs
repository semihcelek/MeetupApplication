using System;
using SemihCelek.MeetupConsoleApplication.Services.MeetupService;
using SemihCelek.MeetupConsoleApplication.Services.UserService;

namespace SemihCelek.MeetupConsoleApplication.Controller
{
    public class CommandLineController
    {
        private readonly UserOperationsController _userOperationsController;
        private readonly MeetupOperationsController _meetupOperationsController;

        public CommandLineController(MeetupService meetupService, UserService userService)
        {
            _meetupOperationsController = new MeetupOperationsController(meetupService);
            _userOperationsController = new UserOperationsController(userService);
        }


        public void InitializeCommandLine()
        {
            Console.WriteLine("Welcome to the meetup application, Please select an action");
            Console.WriteLine("|----------------------------------------------------------|");

            Console.WriteLine(
                "Press (U) For All User Operations.\n" +
                "Press (M) For All Meetup Operations.\n" +
                "Press (Q) For Exit.\n"
            );


            var argumentSelection = Console.ReadKey();

            while (argumentSelection.Key != ConsoleKey.Q)
            {
                switch (argumentSelection.Key)
                {
                    case ConsoleKey.U:
                        _userOperationsController.UserOperations();
                        break;
                    case ConsoleKey.M:
                        _meetupOperationsController.MeetupOperations();
                        break;
                }
            }
        }
    }
}