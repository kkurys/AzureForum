using AzureForum.Posts.Models;
using System.Collections.Generic;
using System.Linq;

namespace AzureForum.Web.ViewModels
{
    public class PostThreadListingViewModel
    {
        public int TotalCount { get; set; }
        public List<PostThreadViewModel> PostThreads { get; set; }
        public PostThreadListingViewModel(PostThreadListing model)
        {
            TotalCount = model.TotalCount;
            PostThreads = model.PostThreads.Select(x => new PostThreadViewModel(x)).ToList();
        }
    }
}
