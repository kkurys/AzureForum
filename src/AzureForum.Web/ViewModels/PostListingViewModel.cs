using AzureForum.Posts.Models;
using System.Collections.Generic;
using System.Linq;

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
