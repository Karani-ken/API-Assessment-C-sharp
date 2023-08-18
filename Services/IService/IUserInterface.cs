using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Assessment.Model;

namespace Week3Assessment.Services.IService
{
    public interface IUserInterface
    {
        //get All users
        Task<List<User>> GetAllUsersAsync();
        //get a user by id
        Task<User> GetByIdAsync(int id);
        //all user posts
        Task<List<Post>> GetUserPostAsync();
        //select a single user
        Task<Post> GetPostByIdAsync(int id);
        //get all comments from a post
        Task<List<Comments>> GetAllCommentsAsync(int postId);

    }
}
