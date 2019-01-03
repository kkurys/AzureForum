using System;
using System.Collections.Generic;
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

        public async Task<Post> CreatePostAsync(AzureForumUser user, string content, PostThread postThread)
        {
            var newPost = new Post
            {
                Content = content,
                CreatedBy = user,
                PostThread = postThread,
                CreatedOn = DateTime.UtcNow
            };

            await _dataService.GetSet<Post>().AddAsync(newPost);
            await _dataService.SaveDbAsync();

            return newPost;
        }

        public async Task<PostThread> CreatePostThreadAsync(AzureForumUser user, string topic)
        {
            var newPostThread = new PostThread
            {
                CreatedById = user.Id,
                CreatedOn = DateTime.UtcNow,
                Topic = topic
            };

            await _dataService.GetSet<PostThread>().AddAsync(newPostThread);
            await _dataService.SaveDbAsync();

            return newPostThread;
        }

        public async Task<PostThreadListing> GetLatestPostThreadsAsync(int skip = 0, int take = 10)
        {
            var result = new PostThreadListing();

            var query = _dataService.GetSet<PostThread>()
                .OrderByDescending(x => x.CreatedBy);

            result.TotalCount = query.Count();
            result.PostThreads = await query
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip * take)
                .Take(take)
                .Include(x => x.CreatedBy)
                .Include(x => x.Posts)
                .ToListAsync();

            return result;
        }

        public async Task<PostListing> GetThreadPostsAsync(PostThread postThread, int skip = 0, int take = 10)
        {
            var result = new PostListing();

            result.ThreadTopic = postThread.Topic;
            result.TotalCount = postThread.Posts.Count;
            result.Posts = postThread.Posts
                .OrderBy(x => x.CreatedOn)
                .Skip(skip * take)
                .Take(take)
                .ToList();

            return result;
        }

        public async Task<List<AzureForumUser>> GetThreadAuthorsAsync(PostThread postThread)
        {
            var authors = postThread.Posts.Select(x => x.CreatedBy).Distinct();

            return authors.ToList();
        }

        public async Task<PostThread> GetPostThreadAsync(string postThreadId)
        {
            var postThread = await _dataService.GetSet<PostThread>()
                .Include(x => x.Posts)
                .ThenInclude(x => x.CreatedBy)
                .FirstOrDefaultAsync(x => x.Id.ToString() == postThreadId);

            return postThread;
        }
    }
}
