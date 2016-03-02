using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace ObscureDesign.Management.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List()
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
