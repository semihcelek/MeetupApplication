using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.MeetupService
{
    public class MeetupService
    {
        private IMeetupDbAccess _dbInstance;

        public MeetupService(IMeetupDbAccess dbInstance)
        {
            _dbInstance = dbInstance;
        }

        public void GetAllMeetups()
        {
            _dbInstance.FindAll();
        }

        public void FindOne(int id)
        {
            _dbInstance.FindOne(id);
        }

        public void CreateMeetup(string name, string description, string subject)
        {
            var meetup = new MeetupModel(name, description, subject);
            _dbInstance.Create(meetup);
        }

        public void UpdateMeetup(string name, string description, string subject)
        {
            var meetup = new MeetupModel(name, description, subject);
            _dbInstance.Update(meetup);
        }

        public void DeleteMeetup(int meetupId)
        {
            _dbInstance.Delete(meetupId);
        }
    }
}