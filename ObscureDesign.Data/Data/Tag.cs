using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace ObscureDesign.Data
{
    public class Tag
    {
        public int TagId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }

        //TODO: tag ico
    }

    public static class TagExtensions
    {
        public static ModelBuilder BuildTag(this ModelBuilder builder)
        {
            builder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
            return builder;
        }
    }
}
