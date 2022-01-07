using System;
using System.Collections.Generic;

namespace SemihCelekBarisKilic.MeetupConsoleApplication.Model
{
    public class MeetupModel
    {
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

        private List<UserModel> _meetupAttendies;

        public MeetupModel(string name, string description)
        {
            this._name = name;
            this._description = description;
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