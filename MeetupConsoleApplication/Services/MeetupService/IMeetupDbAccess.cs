using System.Collections.Generic;
using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.MeetupService
{
    public interface IMeetupDbAccess
    {
        List<MeetupModel> FindAll();
       
        MeetupModel FindOne(int id);
        void Create(MeetupModel meetup);
        void Update(MeetupModel meetup);
        void Delete(int id);
    }
}