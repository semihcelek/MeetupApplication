using System.Collections.Generic;
using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.UserService
{
    public interface IUserDbAccess
    {
        List<UserModel> FindAll();

        UserModel FindOne(int id);
        void Create(UserModel user);
        void Update(UserModel user);
        void Delete(int id);

        void AttendMeetup(MeetupModel meetup);
        void LeaveMeetup(MeetupModel meetup);
    }
}