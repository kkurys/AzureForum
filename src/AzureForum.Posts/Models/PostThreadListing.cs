using System.Collections.Generic;
using AzureForum.Data.Models.Posts;

namespace AzureForum.Posts.Models
{
    public class PostThreadListing
    {
        public List<PostThread> PostThreads { get; set; }
        public int TotalCount { get; set; }
    }
}
