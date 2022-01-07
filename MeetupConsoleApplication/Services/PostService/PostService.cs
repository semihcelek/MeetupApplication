using System;
using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.PostService
{
    public class PostService
    {
        private IPostDbAccess _dbInstance;

        public PostService(IPostDbAccess dbInstance)
        {
            _dbInstance = dbInstance;
        }
        
        public void GetAllPosts()
        {
            _dbInstance.FindAll();
        }

        public void FindOne(int id)
        {
            _dbInstance.FindOne(id);
        }

        public void CreatePost(string title, string content, UserModel author, MeetupModel meetupPost, DateTime date)
        {
            var post = new PostModel(title, content, author, meetupPost, date);
            _dbInstance.Create(post, author.Id);
        }

        public void UpdatePost(string title, string content, UserModel author, MeetupModel meetupPost, DateTime date)
        {
            var post = new PostModel(title, content, author, meetupPost, date);
            _dbInstance.Update(post);
        }
        
        public void DeletePost(int postId)
        {
            _dbInstance.Delete(postId);
        }
    }
}