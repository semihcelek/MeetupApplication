using System;
using System.Collections.Generic;

namespace SemihCelek.MeetupConsoleApplication.Model
{
    public class MeetupModel
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _description;

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        private string _subject;

        public string Subject
        {
            get => _subject;
            set => _subject = value;
        }
        
        private List<UserModel> _meetupAttendies;

        public MeetupModel(string name, string description, string subject)
        {
            _name = name;
            _description = description;
            _subject = subject;
            _meetupAttendies = new List<UserModel>();
        }
        
        public MeetupModel(int id,string name, string description, string subject)
        {
            _id = id;
            _name = name;
            _description = description;
            _subject = subject;
            _meetupAttendies = new List<UserModel>();
        }

        public List<UserModel> GetAttendies()
        {
            return _meetupAttendies;
        }

        public void AddUser(UserModel user)
        {
            _meetupAttendies.Add(user);
        }

        public void RemoveUser(UserModel user)
        {
        }

        public void PrintAttendedUsers()
        {
            foreach (UserModel user in _meetupAttendies)
            {
                Console.WriteLine($"{user.Name} {user.Surname} is attended {_name} event");
            }
        }
    }
}