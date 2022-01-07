using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.PostService
{
    public class MysqlPostAccess : IPostDbAccess
    {
        private readonly MySqlConnection _connection;

        public MysqlPostAccess(MySqlConnection connection)
        {
            _connection = connection;
        }


        public List<PostModel> FindAll()
        {
            List<PostModel> allPosts = new List<PostModel>();
            const string findAllPostSql = "select * from posts;";
            MySqlCommand command = new MySqlCommand(findAllPostSql, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("All Posts are listed as: ");

            while (reader.Read())
            {
                var post = new PostModel(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                    Convert.ToDateTime(reader[5].ToString()));
                allPosts.Add(post);
            }

            foreach (var post in allPosts)
            {
                Console.WriteLine($"{post.Title} {post.Content} {post.CreatedAt}");
            }

            reader.Close();
            return allPosts;
        }

        public PostModel FindOne(int id)
        {
            PostModel post = null;
            const string findPostByIdSql = "select * from posts where id=@id;";
            MySqlCommand command = new MySqlCommand(findPostByIdSql, _connection);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                post = new PostModel(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                    Convert.ToDateTime(reader[5].ToString()));
                Console.WriteLine($"{post.Title} {post.Content} {post.CreatedAt}");
            }
            
            reader.Close();
            return post;

        }

        public void Create(PostModel post, int userId)
        {
            const string insertPostSql =
                "insert into posts(title, content, author, createdAt) values (@title, @content,@author,NOW())";
            try
            {
                MySqlCommand command = new MySqlCommand(insertPostSql, _connection);
                command.Parameters.AddWithValue("@title", post.Title);
                command.Parameters.AddWithValue("@content", post.Content);
                command.Parameters.AddWithValue("@author", userId);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;  
            }
            
        }

        public void Update(PostModel post)
        {
            const string updatePostSql =
                "update posts set title =@title, content=@content, author=@author where id = @postId;";
            try
            {
                MySqlCommand command = new MySqlCommand(updatePostSql, _connection);
                command.Parameters.AddWithValue("@title", post.Title);
                command.Parameters.AddWithValue("@content", post.Content);
                command.Parameters.AddWithValue("@author", post.Author);
                command.Parameters.AddWithValue("@postId", post.Id);

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
            const string deletePostSql = "delete from posts where id = @postId";
            try
            {
                MySqlCommand command = new MySqlCommand(deletePostSql, _connection);
                command.Parameters.AddWithValue("@postId", id);

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