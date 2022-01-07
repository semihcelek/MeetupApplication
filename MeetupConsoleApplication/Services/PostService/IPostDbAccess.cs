using System.Collections.Generic;
using SemihCelek.MeetupConsoleApplication.Model;

namespace SemihCelek.MeetupConsoleApplication.Services.PostService
{
    public interface IPostDbAccess
    {
        List<PostModel> FindAll();
       
        PostModel FindOne(int id);
        void Create(PostModel post, int userId);
        void Update(PostModel post);
        void Delete(int id);
    }
}