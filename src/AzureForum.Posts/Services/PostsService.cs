using System;
using System.Linq;
using System.Threading.Tasks;
using AzureForum.Common.Exceptions;
using AzureForum.Data.Contracts;
using AzureForum.Data.Models.Account;
using AzureForum.Data.Models.Posts;
using AzureForum.Posts.Contracts;
using AzureForum.Posts.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureForum.Posts.Services
{
    public class PostsService : IPostsService
    {
        private readonly IDataService _dataService;

        public PostsService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Post> CreatePost(AzureForumUser user, string content, string postThreadId)
        {
            var newPost = new Post
            {
                Content = content,
                CreatedBy = user,
                PostThreadId = new Guid(postThreadId),
                CreatedOn = DateTime.UtcNow
            };

            await _dataService.GetSet<Post>().AddAsync(newPost);
            await _dataService.SaveDbAsync();

            return newPost;
        }

        public async Task<PostThread> CreatePostThread(AzureForumUser user, string topic)
        {
            var newPostThread = new PostThread
            {
                CreatedById = user.Id,
                Topic = topic
            };

            await _dataService.GetSet<PostThread>().AddAsync(newPostThread);
            await _dataService.SaveDbAsync();

            return newPostThread;
        }

        public async Task<PostThreadListingViewModel> GetLatestPostThreads(int skip = 0, int take = 10)
        {
            var result = new PostThreadListingViewModel();

            var query = _dataService.GetSet<PostThread>()
                .OrderByDescending(x => x.CreatedBy);

            result.TotalCount = query.Count();
            result.PostThreads = await query
                        .Skip(skip * take)
                        .Take(take)
                        .Include(x => x.CreatedBy)
                        .ToListAsync();

            return result;
        }

        public async Task<PostListingViewModel> GetLatestThreadPosts(string postThreadId, int skip = 0, int take = 10)
        {
            var result = new PostListingViewModel();

            var postThread = await _dataService.GetSet<PostThread>()
                .Include(x => x.Posts)
                .FirstOrDefaultAsync(x => x.Id.ToString() == postThreadId);

            if (postThread == null)
            {
                throw new InvalidPostThreadIdException();
            }

            result.TotalCount = postThread.Posts.Count;
            result.Posts = postThread.Posts
                .Skip(skip * take)
                .Take(take)
                .ToList();

            return result;
        }
    }
}
