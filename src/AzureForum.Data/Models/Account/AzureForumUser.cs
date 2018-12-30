using System;
using System.Collections.Generic;
using AzureForum.Data.Models.Posts;
using Microsoft.AspNetCore.Identity;

namespace AzureForum.Data.Models.Account
{
    public class AzureForumUser : IdentityUser<Guid>
    {
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostThread> PostThreads { get; set; }
    }
}