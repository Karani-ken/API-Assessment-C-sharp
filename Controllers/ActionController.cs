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

        }
        public async Task GetAllUsers()
        {
            var Users = await userService.GetAllUsersAsync();

            foreach(var User in Users)
            {
                await Console.Out.WriteLineAsync($"{User.Id} . {User.username}");
            }
        }
        public async Task selectUserPosts(int Id)
        {
            var User = await userService.GetByIdAsync(Id);
            var Posts = await userService.GetUserPostAsync();
            var UserPosts = Posts.FindAll(x => x.userId == User.Id);
            foreach(var Post in UserPosts)
            {
                await Console.Out.WriteLineAsync($"");
            }

        }
    }
}
