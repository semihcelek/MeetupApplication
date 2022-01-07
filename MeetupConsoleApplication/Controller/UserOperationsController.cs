using System;
using SemihCelek.MeetupConsoleApplication.Services.UserService;

namespace SemihCelek.MeetupConsoleApplication.Controller
{
    public class UserOperationsController
    {
        private UserService _userService;

        public UserOperationsController(UserService userService)
        {
            _userService = userService;
        }

        public void UserOperations()
        {
            Console.WriteLine("User Operations are listed as:\n");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine(
                "Press (A) for finding all users.\n" +
                "Press (S) for searching an users with Id.\n" +
                "Press (C) for creating an new user.\n" +
                "Press (U) for updating an user \n" +
                "Press (D) for deleting an users with Id.\n"
            );

            var argumentSelection = Console.ReadKey();

            switch (argumentSelection.Key)
            {
                case ConsoleKey.A:
                    _userService.GetAllUsers();
                    break;

                case ConsoleKey.S:
                    FindUser();
                    break;

                case ConsoleKey.C:
                    RegisterUser();
                    break;

                case ConsoleKey.U:
                    UpdateUser();
                    break;

                case ConsoleKey.D:
                    DeleteUser();
                    break;

                case ConsoleKey.Backspace:
                    return;
            }
        }

        private void DeleteUser()
        {
            Console.WriteLine("Caution!, you're deleting an user this can't be recovered.");
            Console.WriteLine("Please enter an user id to delete");
            var id = Convert.ToInt32(Console.ReadLine());
            _userService.DeleteUser(id);
        }

        private void FindUser()
        {
            Console.WriteLine("Please enter an user id");
            var id = Convert.ToInt32(Console.ReadLine());
            _userService.FindOne(id);
        }

        private void RegisterUser()
        {
            Console.WriteLine("In order to create an user please enter a name");
            var name = Console.ReadLine();

            Console.WriteLine("please enter a surname");
            var surname = Console.ReadLine();

            Console.WriteLine("please enter a email");
            var email = Console.ReadLine();

            Console.WriteLine("please enter a password");
            var password = Console.ReadLine();

            Console.WriteLine("please enter a telNumber");
            var telNumber = Console.ReadLine();

            _userService.CreateUser(name, surname, email, password, telNumber);
        }

        private void UpdateUser()
        {
            Console.WriteLine("In order to update an user please enter a name");
            var name = Console.ReadLine();

            Console.WriteLine("please enter a surname");
            var surname = Console.ReadLine();

            Console.WriteLine("please enter a email");
            var email = Console.ReadLine();

            Console.WriteLine("please enter a password");
            var password = Console.ReadLine();

            Console.WriteLine("please enter a telNumber");
            var telNumber = Console.ReadLine();

            _userService.UpdateUser(name, surname, email, password, telNumber);

            Console.WriteLine($"A new user {name} is created successfully.");
        }
    }
}