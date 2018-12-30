using System;
using AzureForum.Data.Models.Account;

namespace AzureForum.Data.Models.Posts
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid CreatedById { get; set; }
        public Guid PostThreadId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual AzureForumUser CreatedBy { get; set; }
        public virtual PostThread PostThread { get; set; }
    }
}
