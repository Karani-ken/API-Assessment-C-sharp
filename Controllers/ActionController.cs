using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Assessment.Services;

namespace Week3Assessment.Controllers
{
    public class ActionController
    {
        UserService userService = new UserService();
        public async static Task Init()
        {
            Console.WriteLine("All users");
            await new ActionController().GetAllUsers();
            Console.WriteLine("Select a user id to view Posts");
            var input = Console.ReadLine();
            bool Converted = int.TryParse(input, out int Input);
            if (Converted)
            {
                await new ActionController().selectUserPosts(Input);
            }
               

            

        }
        public async Task GetAllUsers()
        {
            var Users = await userService.GetAllUsersAsync();

            foreach(var User in Users)
            {
                await Console.Out.WriteLineAsync($"{User.id} . {User.username}");
            }
        }
        public async Task selectUserPosts(int Id)
        {
            var Users = await userService.GetAllUsersAsync();
            var user = Users.Find(x => x.id == Id);
            var Posts = await userService.GetUserPostAsync();
            var UserPosts = Posts.FindAll(x => x.userId == user.id);  
           
            
           foreach (var Post in UserPosts)
           {
                    await Console.Out.WriteLineAsync($"{Post.id} . {Post.title} , {Post.body} \n");
           }
            
           

            await Console.Out.WriteLineAsync("Enter a post id To view post");
            var input = Console.ReadLine();
            bool Converted = int.TryParse(input, out int Input);
            if (Converted)
            {
                await new ActionController().ViewPostComments(Input);
            }

           
            
        }
        public async Task ViewPostComments(int Id)
        {
            var comments = await userService.GetAllCommentsAsync();
            var userComments = comments.FindAll(x=> x.postId == Id);
            foreach( var comment in userComments)
            {
                await Console.Out.WriteLineAsync($"{comment.id} . {comment.name} , {comment.body}\n");
            }

        }
    }
}
