using AzureForum.Data.Models.Posts;
using System.Threading.Tasks;
using AzureForum.Data.Models.Account;
using AzureForum.Posts.Models;

namespace AzureForum.Posts.Contracts
{
    public interface IPostsService
    {
        Task<Post> CreatePostAsync(AzureForumUser user, string content, string postThreadId);
        Task<PostThread> CreatePostThreadAsync(AzureForumUser user, string topic);
        Task<PostThreadListing> GetLatestPostThreadsAsync(int skip = 0, int take = 10);
        Task<PostListing> GetThreadPostsAsync(string postThreadId, int skip = 0, int take = 10);
    }
}
