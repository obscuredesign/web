using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ObscureDesign.Data;
using ObscureDesign.Management.Models;

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
            var model = new ArticleModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ArticleModel model)
        {
            return View();
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
