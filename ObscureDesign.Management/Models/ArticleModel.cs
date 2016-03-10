using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Management.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Url slug")]
        public string Slug { get; set; }

        public string Abstract { get; set; }
        public string Content { get; set; }
        public string Conclusion { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Published { get; set; }

        public UserModel Author { get; set; }

        public List<string> Tags { get; set; }
    }

    public static class ArticleModelExtensions
    {
        public static IEnumerable<ArticleModel> ToViewModel(this IQueryable<Data.Article> source, bool includeContent = true, bool includeTags = true)
        {
            return source.Select(article => new ArticleModel
            {
                Id = article.ArticleId,
                Title = article.Title,
                Slug = article.Slug,
                Abstract = article.Abstract,
                Content = article.Content,
                Conclusion =  article.Conclusion,
                Created = article.Created,
                Updated = article.Updated,
                Published = article.Published,
                Author = article.Author.ToViewModel(),
                Tags = article.ArticleTags.Select(at => at.Tag.Name).ToList(),
            });

            // this should work if not for EF bugs with ternary operator

            //return source.Select(article => new ArticleModel
            //{
            //    Id = article.ArticleId,
            //    Title = article.Title,
            //    Slug = article.Slug,
            //    //Abstract = includeContent ? article.Abstract : null,
            //    //Content = includeContent ? article.Content : null,
            //    //Conclusion = includeContent ? article.Conclusion : null,
            //    //TODO processors
            //    Created = article.Created,
            //    Updated = article.Updated,
            //    Published = article.Published,
            //    Author = article.Author.ToViewModel(),
            //    //Tags = includeTags ? article.ArticleTags.Select(at => at.Tag.Name).ToList() : null,
            //});
        }
    }
}
