using System;
using AzureForum.Data.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzureForum.Data
{
    public class AzureForumDbContext : IdentityDbContext<AzureForumUser, AzureForumRole, Guid>
    {
        public AzureForumDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}