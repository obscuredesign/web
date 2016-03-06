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

        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
