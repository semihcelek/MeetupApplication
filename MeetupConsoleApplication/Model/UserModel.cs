using System;
using System.Collections.Generic;

namespace SemihCelekBarisKilic.MeetupConsoleApplication.Model
{
    public class UserModel
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

        private string _surname;

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        private string _email;

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        private string _passwordHash;

        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = value;
        }

        private string _telNumber;

        public string TelNumber
        {
            get => _telNumber;
            set => _telNumber = value;
        }

        private bool _isActive { get; }
        private bool _isAdmin { get; }

        private List<MeetupModel> _attendedMeetups;

        public UserModel(int id, string name, string surname, string email, string passwordHash, string telNumber)
        {
            this._id = id;
            this._name = name;
            this._surname = surname;
            this._email = email;
            this._passwordHash = passwordHash;
            this._telNumber = telNumber;
            _attendedMeetups = new List<MeetupModel>();
        }

        public void AttendMeetup(MeetupModel meetup)
        {
            _attendedMeetups.Add(meetup);
        }
    }
}