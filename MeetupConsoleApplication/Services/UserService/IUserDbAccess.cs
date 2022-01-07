using System.Collections.Generic;
using SemihCelekBarisKilic.MeetupConsoleApplication.Model;

namespace SemihCelekBarisKilic.MeetupConsoleApplication.Services.UserService
{
    public interface IUserDbAccess
    {
        List<UserModel> FindAll();

        UserModel FindOne(int id);
        void Create(UserModel user);
        void Update(UserModel user);
        void Delete(int id);
    }
}