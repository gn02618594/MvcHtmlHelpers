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
    }
}