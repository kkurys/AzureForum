using System;
using AzureForum.Data.Models.Account;
using AzureForum.Data.Models.Posts;

namespace AzureForum.Web.ViewModels
{
    public class PostViewModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public AzureForumUserViewModel CreatedBy { get; set; }
        public PostViewModel(Post post)
        {
            Id = post.Id.ToString();
            Content = post.Content;
            CreatedOn = post.CreatedOn;
            CreatedBy = new AzureForumUserViewModel(post.CreatedBy);
        }
    }
}
