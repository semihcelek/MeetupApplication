using System;
using SemihCelek.MeetupConsoleApplication.Services.MeetupService;

namespace SemihCelek.MeetupConsoleApplication.Controller
{
    public class MeetupOperationsController
    {
        private MeetupService _meetupService;

        public MeetupOperationsController(MeetupService meetupService)
        {
            _meetupService = meetupService;
        }

        public void MeetupOperations()
        {
            Console.WriteLine("Meetup Operations are listed as:\n");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine(
                "Press (A) for finding all meetups.\n" +
                "Press (S) for searching an meetup with Id.\n" +
                "Press (C) for creating an new meetup.\n" +
                "Press (U) for updating an meetup \n" +
                "Press (D) for deleting an meetup with Id.\n"
            );

            var argumentSelection = Console.ReadKey();

            switch (argumentSelection.Key)
            {
                case ConsoleKey.A:
                    _meetupService.GetAllMeetups();
                    break;

                case ConsoleKey.S:
                    FindMeetup();
                    break;

                case ConsoleKey.C:
                    RegisterMeetup();
                    break;

                case ConsoleKey.U:
                    UpdateMeetup();
                    break;

                case ConsoleKey.D:
                    DeleteMeetup();
                    break;

                case ConsoleKey.Backspace:
                    return;
            }
        }

        private void DeleteMeetup()
        {
            Console.WriteLine("Caution!, you're deleting an meetup this can't be recovered.");
            Console.WriteLine("Please enter an meetup id to delete");
            var id = Convert.ToInt32(Console.ReadLine());
            _meetupService.DeleteMeetup(id);
        }

        private void UpdateMeetup()
        {
            Console.WriteLine("In order to update an meetup please enter a meetup name");
            var name = Console.ReadLine();

            Console.WriteLine("please enter a  new description");
            var description = Console.ReadLine();

            Console.WriteLine("please enter a  new subject");
            var subject = Console.ReadLine();

            _meetupService.UpdateMeetup(name, description, subject);
        }

        private void RegisterMeetup()
        {
            Console.WriteLine("In order to create an meetup please enter a meetup name");
            var name = Console.ReadLine();

            Console.WriteLine("please enter a description");
            var description = Console.ReadLine();

            Console.WriteLine("please enter a subject");
            var subject = Console.ReadLine();

            _meetupService.CreateMeetup(name, description, subject);
            Console.WriteLine($"{name} meetup is created successfully.");
        }

        private void FindMeetup()
        {
            Console.WriteLine("Please enter an meetup id");
            var id = Convert.ToInt32(Console.ReadLine());
            _meetupService.FindOne(id);
        }
    }
}