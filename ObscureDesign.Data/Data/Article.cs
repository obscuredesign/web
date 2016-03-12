using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Data
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Slug{ get; set; }

        [Required]
        public string Abstract { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Conclusion { get; set; }

        [Required]
        public string PreprocessorAQM { get; set; } //TODO: remove
        [Required]
        public string PostprocessorAQM { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Published { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }

        //TODO: QR code      
    }

    internal static class ArticleExtensions
    {
        public static ModelBuilder BuildArticle(this ModelBuilder builder)
        {
            builder.Entity<Article>().HasIndex(a => a.Slug).IsUnique();
            return builder;
        }
    }

    public static class ArticleServices
    {
        //public static
    }
}
