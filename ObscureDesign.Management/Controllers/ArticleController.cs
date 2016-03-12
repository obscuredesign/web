using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
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
                // TODO: Here we should probably create transaction or something
                
                var article = new Article
                {
                    Title = model.Title,
                    Slug = model.Slug,
                    Abstract = model.Abstract ?? string.Empty,
                    Content = model.Content ?? string.Empty,
                    Conclusion = model.Conclusion ?? string.Empty,
                    PreprocessorAQM = ProcessorHelper.CreatePreprocessor(new string[0]).AssemblyQualifiedName,
                    PostprocessorAQM = ProcessorHelper.CreatePostprocessor(model.GetActiveProcessorNames()).AssemblyQualifiedName,
                    Created = model.Created,
                    Updated = DateTime.UtcNow,
                    Published = model.Published,
                    AuthorId = model.Author.Id,
                };
                Context.Articles.Add(article);
                Context.SaveChanges();

                //Context.Tags.MergeAll(model.Tags);
                //Context.SaveChanges();

                //var tags = Context.Tags.Search(model.Tags);
                //Context.ArticleTags.Connect(article, tags);
                //Context.SaveChanges();

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
