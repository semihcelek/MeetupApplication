using MySql.Data.MySqlClient;

namespace SemihCelekBarisKilic.MeetupConsoleApplication.Services
{
    public class UserService
    {
        private IUserDbAccess _dbInstance;

        public UserService(IUserDbAccess dbInstance)
        {
            this._dbInstance = dbInstance;
        }

        public void GetAllUsers()
        {
            _dbInstance.FindAll();
        }

        public void FindOne(int id)
        {
            _dbInstance.FindOne(id);
        }
    }
}