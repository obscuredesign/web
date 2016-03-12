using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ObscureDesign.Processors;
using Microsoft.AspNet.Mvc.Rendering;

namespace ObscureDesign.Management.Models
{
    public class ArticleModel
    {
        #region View management

        public ArticleModelEditViewManagement EditViewManagement { get; set; }

        #endregion

        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Url slug")]
        public string Slug { get; set; }

        public string Abstract { get; set; }
        public string Content { get; set; }
        public string Conclusion { get; set; }

        public Dictionary<string, int?> Postprocessors { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Published { get; set; }

        public UserModel Author { get; set; }

        public List<string> Tags { get; set; }

        public IEnumerable<string> GetActiveProcessorNames() => Postprocessors
            .Where(pp => pp.Value != null)
            .OrderBy(pp => pp.Value)
            .Select(pp => pp.Key);
    }

    public class ArticleModelEditViewManagement
    {
        public ArticleModelEditViewManagement(IQueryable<Data.User> users)
        {
            AvailablePostprocessors = ProcessorHelper.GetPostprocessors()
                .ToDictionary(ppType => ppType.AssemblyQualifiedName, ppType => ppType.GetProcessorDisplayName());

            AvailableAuthors =
                new SelectListItem[]
                {
                    new SelectListItem
                    {
                        Value = null,
                        Text = string.Empty,
                    }
                }.Concat(
                    users.Select(u => new SelectListItem
                    {
                        Value = u.UserId.ToString(),
                        Text = u.DisplayName,
                    })
                );
        }

        public Dictionary<string, string> AvailablePostprocessors { get; }
        public IEnumerable<SelectListItem> AvailableAuthors { get; }
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
            //    Postprocessors = ?
            //    Created = article.Created,
            //    Updated = article.Updated,
            //    Published = article.Published,
            //    Author = article.Author.ToViewModel(),
            //    //Tags = includeTags ? article.ArticleTags.Select(at => at.Tag.Name).ToList() : null,
            //});
        }
    }
}
