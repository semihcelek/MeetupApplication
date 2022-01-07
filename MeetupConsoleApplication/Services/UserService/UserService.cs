using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.UserService
{
    public class UserService
    {
        private IUserDbAccess _dbInstance;

        public UserService(IUserDbAccess dbInstance)
        {
            _dbInstance = dbInstance;
        }

        public void GetAllUsers()
        {
            _dbInstance.FindAll();
        }

        public void FindOne(int id)
        {
            _dbInstance.FindOne(id);
        }

        public void CreateUser(string name, string surname, string email, string password, string telNumber)
        {
            var user = new UserModel(name, surname, email, password, telNumber);
            _dbInstance.Create(user);
        }

        public void UpdateUser(string name, string surname, string email, string password, string telNumber)
        {
            var user = new UserModel(name, surname, email, password, telNumber);
            _dbInstance.Update(user);
        }

        public void DeleteUser(int userId)
        {
            _dbInstance.Delete(userId);
        }
    }
}