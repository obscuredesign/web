using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace ObscureDesign.Data
{
    public class ArticleTag
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

    internal static class ArticleTagExtensions
    {
        public static ModelBuilder BuildArticleTag(this ModelBuilder builder)
        {
            builder.Entity<ArticleTag>().HasKey(at => new { at.TagId, at.ArticleId });
            return builder;
        }
    }

    public static class ArticleTagServices
    {
        public static void Connect(this DbSet<ArticleTag> source, Article article, IQueryable<Tag> tags)
        {
            var articleTags = tags.Select(t => new ArticleTag
            {
                ArticleId = article.ArticleId,
                TagId = t.TagId,
            }).ToList();
            source.AddRange(articleTags);
        }
    }
}
