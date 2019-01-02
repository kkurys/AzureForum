using AzureForum.Data.Models.Posts;
using System.Collections.Generic;

namespace AzureForum.Posts.Models
{
    public class PostListing
    {
        public List<Post> Posts { get; set; }
        public int TotalCount { get; set; }
    }
}
