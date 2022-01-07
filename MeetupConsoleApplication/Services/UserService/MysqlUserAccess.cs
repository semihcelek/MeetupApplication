using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.UserService
{
    public class MysqlUserAccess : IUserDbAccess
    {
        private MySqlConnection _connection;

        public MysqlUserAccess(MySqlConnection dbInstance)
        {
            _connection = dbInstance;
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
                Console.WriteLine($"{user.Name}, {user.Surname} has id of {user.Id}");
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
                user = new UserModel(Convert.ToInt32(reader[0]), reader[1].ToString(),  reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
            }

            Console.WriteLine(user.Id + "- " + user.Name + " " + user.Surname + " " + user.TelNumber);

            reader.Close();
            return user;
        }

        public void Create(UserModel user)
        {
            var insertUserSql =
                "insert into users(name, surname, email, passwordHash, isActive, isAdmin) values (@name, @surname, @email, @passwordHash, true, false);";
            try
            {
                MySqlCommand command = new MySqlCommand(insertUserSql, _connection);

                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@passwordHash", user.PasswordHash);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(UserModel user)
        {
            var updateUserSql =
                "update users set name = @name, surname = @surname, email = @email, passwordHash = @passwordHash where id=@userId;";
            try
            {
                MySqlCommand command = new MySqlCommand(updateUserSql, _connection);

                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
                command.Parameters.AddWithValue("@userId", user.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            var deleteUserSql = "delete from users where id = @userid";

            try
            {
                MySqlCommand command = new MySqlCommand(deleteUserSql, _connection);
                command.Parameters.AddWithValue("@userid", id);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AttendMeetup(MeetupModel meetup)
        {
            throw new NotImplementedException();
        }

        public void LeaveMeetup(MeetupModel meetup)
        {
            throw new NotImplementedException();
        }
    }
}