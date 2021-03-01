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
        public ActionResult Details(int? Id)
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Id,Name,Mobile,Email,Department,Title")] Employee emp)
        {
            //用 ModelState.IsValid 判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                //通過驗證，將資料異動儲存到資料庫
                db.Employees.Add(emp);
                db.SaveChanges();
                //儲存完成後，導向 Index 動作方法
                return RedirectToAction("Index");
            }
            //若未通過驗證，再次返回顯示 Form 表單，直到資料提交完全正確
            return View(emp);
        }
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return Content("查無此資料，請提供員工編號");
            }
            Employee emp = db.Employees.Find(Id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,Name,Mobile,Email,Department,Title")] Employee emp) {
            if (ModelState.IsValid)
            {
                db.Entry(db).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return Content("查無此資料，請提供員工編號");
            }
            Employee emp = db.Employees.Find(Id);

            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id) {
            Employee emp = db.Employees.Find(Id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}