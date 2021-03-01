using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHtmlHelpers.Models;
using System.Net;
using System.Data.Entity;

namespace MvcHtmlHelpers.Controllers
{
    public class EmployeesController : Controller
    {
        private CmsContext db = new CmsContext();
        // GET: Employees
        public ActionResult Index()
        {
            var emps = db.Employees.ToList();
            return View(emps);
        }
        public ActionResult Details(int Id)
        {
            //檢查是否有員工 Id 的判斷
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //以 Id 找尋員工資料
            Employee emp = db.Employees.Find(Id);

            //如果沒有找到員工，回傳 HttpNotFound
            if(emp ==null)
            {
                return HttpNotFound();
            }


            return View(emp);
        }
    }
}