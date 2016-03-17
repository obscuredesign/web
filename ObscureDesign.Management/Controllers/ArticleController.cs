using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ObscureDesign.Data;
using ObscureDesign.Management.Models;
using ObscureDesign.Processors;

namespace ObscureDesign.Management.Controllers
{
    public class ArticleController : Controller
    {
        [FromServices] public AppDbContext Context { get; set; }


        public IActionResult List()
        {
            var model = Context.Articles.ToViewModel(includeContent: false, includeTags: false);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ArticleModel
            {
                EditViewManagement = new ArticleModelEditViewManagement(Context.Users),
                Created = DateTime.UtcNow,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ArticleModel model)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = Context.Database.BeginTransaction(IsolationLevel.Serializable))
                {
                    var article = Context.Articles.Create(
                        title: model.Title,
                        urlSlug: model.Slug,
                        authorId: model.Author.Id,
                        postprocessorAQNs: model.GetActiveProcessorNames(),
                        created: model.Created,
                        published: model.Published,
                        textAbstract: model.Abstract,
                        textContent: model.Content,
                        textConclusion: model.Conclusion
                    );
                    Context.SaveChanges();

                    Context.Tags.CreateAllIfNotExists(model.Tags);
                    Context.SaveChanges();

                    var tags = Context.Tags.SearchAll(model.Tags);
                    Context.ArticleTags.ConnectTagsToArticle(article, tags);
                    Context.SaveChanges();

                    transaction.Commit();
                }

                return RedirectToAction(nameof(List));
            }

            model.EditViewManagement = new ArticleModelEditViewManagement(Context.Users);
            return View(model);
        }

        public IActionResult EditContent()
        {
            return View();
        }

        public IActionResult EditComments()
        {
            return View();
        }
    }
}
