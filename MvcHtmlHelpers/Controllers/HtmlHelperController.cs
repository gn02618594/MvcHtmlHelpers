using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHtmlHelpers.Models;

namespace MvcHtmlHelpers.Controllers
{
    public class HtmlHelperController : Controller
    {
        // GET: HtmlHelper
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SampleHelpers() {
            User register = new User
            {
                Id = 1001,
                Name = "楊XX",
                Nickname = "可以的",
                Email = "gnxxxxxx@gmail.com",
                City = 2,
                Terms = true
            };

            ViewData.Model = register;

            return View();
        }
        public ActionResult ValidationMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidationMessage(User user)
        {
            if (ModelState.IsValid) {
                return Content("成功!");
            }
            return View(user);
        }
        public ActionResult EditorFor() {
            RegisterDataAnnotations register = new RegisterDataAnnotations
            {
                Id = 1,
                Name = "可以的",
                Password = "myPassword",
                Email = "gn@gmail.com",
                HomePage = "https://gn02618594.github.io/",
                Gender = Gender.Male,
                Birthday = new DateTime(1993, 6, 3),
                Birthday2 = new DateTime(1993, 6, 3),
                City = 4,
                Commutermode = "1",
                Comment = "請留下您的意見",
                Terms = true
            };
            return View(register);
        }

        public ActionResult HelperBootstrap() {
            Register register = new Register { 
            Id=1,
            Name="Andy",
            Email="gn@gmail.com"
            };
            return View();
        }
    }
}