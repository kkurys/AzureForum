using AzureForum.Data.Models.Account;
using System;
using System.Collections.Generic;

namespace AzureForum.Data.Models.Posts
{
    public class PostThread
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public Guid CreatedById { get; set; }
        public virtual AzureForumUser CreatedBy { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
