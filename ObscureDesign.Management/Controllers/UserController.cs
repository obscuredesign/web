using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ObscureDesign.Data;
using ObscureDesign.Management.Models;

namespace ObscureDesign.Management.Controllers
{
    public class UserController : Controller
    {
        [FromServices]
        public AppDbContext Context { get; set; }

        public IActionResult List()
        {
            var model = Context.Users.ToViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = Context.Users.Find(id).ToViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserModel model)
        {
            return RedirectToAction(nameof(List));
        }
    }
}
