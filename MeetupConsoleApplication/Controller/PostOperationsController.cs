using System;
using SemihCelek.MeetupConsoleApplication.Services.PostService;

namespace SemihCelek.MeetupConsoleApplication.Controller
{
    public class PostOperationsController
    {
        private PostService _postService;

        public PostOperationsController(PostService postService)
        {
            _postService = postService;
        }

        public void PostOperations()
        {
            Console.WriteLine("Post Operations are listed as:\n");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine(
                "Press (A) for finding all post.\n" +
                "Press (S) for searching an post with Id.\n" +
                "Press (C) for creating an new post.\n" +
                "Press (U) for updating an post \n" +
                "Press (D) for deleting an posts with Id.\n"
            );

            var argumentSelection = Console.ReadKey();

            switch (argumentSelection.Key)
            {
                case ConsoleKey.A:
                    _postService.GetAllPosts();
                    break;

                case ConsoleKey.S:
                    FindPost();
                    break;

                case ConsoleKey.C:
                    CreatePost();
                    break;

                case ConsoleKey.U:
                    UpdatePost();
                    break;

                case ConsoleKey.D:
                    DeletePost();
                    break;

                case ConsoleKey.Backspace:
                    return;
            }
        }

        private void DeletePost()
        {
            Console.WriteLine("Caution!, you're deleting an post this can't be recovered.");
            Console.WriteLine("Please enter an post id to delete");
            var id = Convert.ToInt32(Console.ReadLine());
            _postService.DeletePost(id);
        }

        private void FindPost()
        {
            Console.WriteLine("Please enter an user id");
            var id = Convert.ToInt32(Console.ReadLine());
            _postService.FindOne(id);
        }

        private void CreatePost()
        {
            Console.WriteLine("In order to create an user please enter a title");
            var title = Console.ReadLine();

            Console.WriteLine("please enter a content");
            var content = Console.ReadLine();

            Console.WriteLine("please enter a email");
            var email = Console.ReadLine();

            Console.WriteLine("please enter a password");
            var password = Console.ReadLine();

            Console.WriteLine("please enter a telNumber");
            var telNumber = Console.ReadLine();

            // _postService.CreatePost(title,content,author,meetupPost,date);
            throw new NotImplementedException();
        }

        private void UpdatePost()
        {
            Console.WriteLine("In order to update an user please enter a name");
            var name = Console.ReadLine();

            Console.WriteLine("please enter a surname");
            var surname = Console.ReadLine();

            Console.WriteLine("please enter a email");
            var email = Console.ReadLine();

            Console.WriteLine("please enter a password");
            var password = Console.ReadLine();

            Console.WriteLine("please enter a telNumber");
            var telNumber = Console.ReadLine();


            Console.WriteLine($"A new user {name} is created successfully.");

            throw new NotImplementedException();
        }
    }
}