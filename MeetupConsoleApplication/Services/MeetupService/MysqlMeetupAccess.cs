using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.MeetupService
{
    public class MysqlMeetupAccess : IMeetupDbAccess
    {
        private readonly MySqlConnection _connection;

        public MysqlMeetupAccess(MySqlConnection dbInstance)
        {
            _connection = dbInstance;
        }


        public List<MeetupModel> FindAll()
        {
            List<MeetupModel> allMeetups = new List<MeetupModel>();
            const string findAllMeetupSql = "select * from meetups;";
            MySqlCommand command = new MySqlCommand(findAllMeetupSql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("All Meetups are listed as: ");

            while (reader.Read())
            {
                var meetup = new MeetupModel(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString());
                allMeetups.Add(meetup);
            }

            foreach (var meetup in allMeetups)
            {
                Console.WriteLine($"{meetup.Name} is a meetup with {meetup.Id} id.");
            }

            reader.Close();
            return allMeetups;
        }

        public MeetupModel FindOne(int id)
        {
            MeetupModel meetup = null;
            const string findMeetupByIdSql = "select * from meetups where id=@id;";
            MySqlCommand command = new MySqlCommand(findMeetupByIdSql, _connection);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                meetup = new MeetupModel(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString());
                Console.WriteLine($"{meetup.Id}- {meetup.Description} {meetup.Subject}");

            }

            reader.Close();
            return meetup;
        }

        public void Create(MeetupModel meetup)
        {
            const string insertMeetupSql =
                "insert into meetups(name, description, subject, createdAt) values (@name, @description, @subject, NOW())";
            try
            {
                MySqlCommand command = new MySqlCommand(insertMeetupSql, _connection);
                command.Parameters.AddWithValue("@name", meetup.Name);
                command.Parameters.AddWithValue("@description", meetup.Description);
                command.Parameters.AddWithValue("@subject", meetup.Subject);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(MeetupModel meetup)
        {
            const string updateMeetupSql =
                "update meetups set name =@name,description =  @description, subject =  @subject where id=@meetupId;";
            try
            {
                MySqlCommand command = new MySqlCommand(updateMeetupSql, _connection);
                command.Parameters.AddWithValue("@name", meetup.Name);
                command.Parameters.AddWithValue("@description", meetup.Description);
                command.Parameters.AddWithValue("@subject", meetup.Subject);
                command.Parameters.AddWithValue("@meetupId", meetup.Id);

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
            const string deleteMeetupSql = "delete from meetups where id = @meetupId";

            try
            {
                MySqlCommand command = new MySqlCommand(deleteMeetupSql, _connection);
                command.Parameters.AddWithValue("@meetupId", id);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}