using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace ObscureDesign.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.BuildArticleTag()
                   .BuildTag();
        }
    }
}
