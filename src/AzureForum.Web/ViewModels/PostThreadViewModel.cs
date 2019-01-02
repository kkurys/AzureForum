using System;
using System.Linq;
using AzureForum.Data.Models.Posts;

namespace AzureForum.Web.ViewModels
{
    public class PostThreadViewModel
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public AzureForumUserViewModel CreatedBy { get; set; }
        public int RepliesCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public PostThreadViewModel(PostThread x)
        {
            Id = x.Id.ToString();
            Topic = x.Topic;
            CreatedBy = new AzureForumUserViewModel(x.CreatedBy);
            RepliesCount = x.Posts.Count;
            CreatedOn = x.Posts.First().CreatedOn;
        }
    }
}
