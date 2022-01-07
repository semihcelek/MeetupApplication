using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SemihCelekBarisKilic.MeetupConsoleApplication.Model;

namespace SemihCelekBarisKilic.MeetupConsoleApplication.Services
{
    public interface IUserDbAccess
    {
        List<UserModel> FindAll();

        UserModel FindOne(int id);
        bool Create(UserModel user);
        bool Update(UserModel user);
        bool Delete(int id);
    }

    public class MysqlUserAccess : IUserDbAccess
    {
        private MySqlConnection _connection;

        public MysqlUserAccess(MySqlConnection dbInstance)
        {
            this._connection = dbInstance;
        }

        public List<UserModel> FindAll()
        {
            List<UserModel> allUsers = new List<UserModel>();
            var findAllUsersSql = "select * from users;";
            MySqlCommand command = new MySqlCommand(findAllUsersSql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("All Users are listed as:");
            while (reader.Read())
            {
                var user = new UserModel(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                allUsers.Add(user);
            }

            foreach (var user in allUsers)
            {
                Console.WriteLine(user.Name);
            }

            reader.Close();
            return allUsers;
        }

        public UserModel FindOne(int id)
        {
            UserModel user = null;
            var findUserByIdSql = "select * from users where id = " + id + ";";
            MySqlCommand command = new MySqlCommand(findUserByIdSql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Single User is listed as:");
            while (reader.Read())
            {
                user = new UserModel(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
            }

            reader.Close();
            return user;
        }

        public bool Create(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}