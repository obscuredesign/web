﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ObscureDesign.Processors;

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
        /// <summary>
        /// 
        /// </summary>
        public static Article Create(this DbSet<Article> source,
            string title,
            string urlSlug,
            int authorId,
            string textAbstract,
            string textContent,
            string textConclusion,
            IEnumerable<string> postprocessorAQNs = null,
            DateTime? created = null,
            DateTime? updated = null,
            DateTime? published = null)
        {
            var article = new Article
            {
                Title = title,
                Slug = urlSlug,
                Abstract = textAbstract,
                Content = textContent,
                Conclusion = textConclusion,
                PostprocessorAQM = ProcessorHelper.CreatePostprocessor(postprocessorAQNs).AssemblyQualifiedName,
                Created = created,
                Updated = updated ?? DateTime.UtcNow,
                Published = published,
                AuthorId = authorId,
            };
            source.Add(article);
            return article;
        }
    }
}
