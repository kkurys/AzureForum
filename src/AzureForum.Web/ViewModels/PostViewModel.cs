using AzureForum.Data.Models.Posts;

namespace AzureForum.Web.ViewModels
{
    public class PostViewModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string CreatedOn { get; set; }
        public AzureForumUserViewModel CreatedBy { get; set; }
        public PostViewModel(Post post)
        {
            Id = post.Id.ToString();
            Content = post.Content;
            CreatedOn = post.CreatedOn.ToString("g");
            CreatedBy = new AzureForumUserViewModel(post.CreatedBy);
        }
    }
}
