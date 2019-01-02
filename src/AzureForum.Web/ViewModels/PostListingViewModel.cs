using System.Collections.Generic;
using System.Linq;
using AzureForum.Data.Models.Posts;
using AzureForum.Posts.Models;

namespace AzureForum.Web.ViewModels
{
    public class PostListingViewModel
    {
        public int TotalCount { get; set; }
        public List<PostViewModel> Posts { get; set; }
        public PostListingViewModel(PostListing model)
        {
            TotalCount = model.TotalCount;
            Posts = model.Posts.Select(x => new PostViewModel(x)).ToList();
        }
    }
}
