using System;
using SemihCelekBarisKilic.MeetupConsoleApplication.Model;

namespace SemihCelekBarisKilic.MeetupConsoleApplication.Services.UserService
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

        public void CreateUser(UserModel user)
        {
            _dbInstance.Create(user);
        }

        public void UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            _dbInstance.Delete(userId);
        }
    }
}