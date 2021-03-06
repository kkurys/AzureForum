﻿using System.Collections.Generic;
using AzureForum.Data.Models.Posts;
using System.Threading.Tasks;
using AzureForum.Data.Models.Account;
using AzureForum.Posts.Models;

namespace AzureForum.Posts.Contracts
{
    public interface IPostsService
    {
        Task<Post> CreatePostAsync(AzureForumUser user, string content, PostThread thread);
        Task<PostThread> CreatePostThreadAsync(AzureForumUser user, string topic);
        Task<PostThreadListing> GetLatestPostThreadsAsync(int skip = 0, int take = 10);
        PostListing GetThreadPosts(PostThread thread, int skip = 0, int take = 10);
        List<AzureForumUser> GetThreadAuthors(PostThread thread);
        Task<PostThread> GetPostThreadAsync(string postThreadId);
    }
}
