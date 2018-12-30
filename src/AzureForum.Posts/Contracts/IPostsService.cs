using AzureForum.Data.Models.Posts;
using System.Threading.Tasks;
using AzureForum.Data.Models.Account;
using AzureForum.Posts.Models;

namespace AzureForum.Posts.Contracts
{
    public interface IPostsService
    {
        Task<Post> CreatePost(AzureForumUser user, string content, string postThreadId);
        Task<PostThread> CreatePostThread(AzureForumUser user, string topic);
        Task<PostThreadListingViewModel> GetLatestPostThreads(int skip = 0, int take = 10);
        Task<PostListingViewModel> GetLatestThreadPosts(string postThreadId, int skip = 0, int take = 10);
    }
}
