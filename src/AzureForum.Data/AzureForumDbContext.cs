using System;
using AzureForum.Data.Models.Account;
using AzureForum.Data.Models.Posts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzureForum.Data
{
    public class AzureForumDbContext : IdentityDbContext<AzureForumUser, AzureForumRole, Guid>
    {
        public DbSet<PostThread> PostThreads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public AzureForumDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigurePostModel(builder);
            ConfigurePostThreadModel(builder);

            base.OnModelCreating(builder);
        }

        private void ConfigurePostModel(ModelBuilder builder)
        {
            builder.Entity<Post>()
                .HasOne(x => x.PostThread)
                .WithMany(x => x.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(x => x.CreatedBy)
                .WithMany(x => x.Posts);
        }

        private void ConfigurePostThreadModel(ModelBuilder builder)
        {
            builder.Entity<PostThread>()
                .HasOne(x => x.CreatedBy)
                .WithMany(x => x.PostThreads);
        }
    }
}