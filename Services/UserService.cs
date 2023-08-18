
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using Week3Assessment.Model;
using Week3Assessment.Services.IService;

namespace Week3Assessment.Services
{
    public class UserService : IUserInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string _posts = " http://localhost:3000/posts";
        private readonly string _users = "  http://localhost:3000/users ";
        private readonly string _comments= "  http://localhost:3000/comments ";


        public UserService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Comments>> GetAllCommentsAsync(int postId)
        {
            var response = await _httpClient.GetAsync(_comments + "/" + postId);
            var Comments = JsonConvert.DeserializeObject<List<Comments>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return Comments;
            }
            throw new Exception("Could not Fetch post Comments");
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync(_users);
            var Users = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return Users;
            }
            throw new Exception("Could not Fetch users");
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(_users +"/" + id);
            var User = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return User;
            }
            throw new Exception("Could not Fetch user");
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(_posts + "/" + id);
            var Post = JsonConvert.DeserializeObject<Post>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return Post;
            }
            throw new Exception("Could not Fetch post");
        }

        public async Task<List<Post>> GetUserPostAsync()
        {
            var response = await _httpClient.GetAsync(_posts);
            var Posts = JsonConvert.DeserializeObject<List<Post>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return Posts;
            }
            throw new Exception("Could not Fetch posts");
        }
    }
}
