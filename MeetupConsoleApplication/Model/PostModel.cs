using System;

namespace SemihCelek.MeetupConsoleApplication.Model
{
    public class PostModel
    {
        private int _id;
        
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        private string _content;

        public string Content
        {
            get => _content;
            set => _content = value;
        }

        private UserModel _author;

        public UserModel Author
        {
            get => _author;
            set => _author = value;
        }

        private MeetupModel _meetupPost;

        public MeetupModel MeetupPost
        {
            get => _meetupPost;
            set => _meetupPost = value;
        }

        private DateTime _createdAt;

        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public PostModel(int id, string title, string content, DateTime createdAt)
        {
            _id = id;
            _title = title;
            _content = content;
            _createdAt = createdAt;
        }

        public PostModel(int id, string title, string content, UserModel author, MeetupModel meetupPost,
            DateTime createdAt)
        {
            _id = id;
            _title = title;
            _content = content;
            _author = author;
            _meetupPost = meetupPost;
            _createdAt = createdAt;
        }

        public PostModel(string title, string content, UserModel author, MeetupModel meetupPost, DateTime createdAt)
        {
            _title = title;
            _content = content;
            _author = author;
            _meetupPost = meetupPost;
            _createdAt = createdAt;
        }
    }
}