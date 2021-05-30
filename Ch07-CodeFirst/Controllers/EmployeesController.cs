using Ch07_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ch07_CodeFirst.Controllers
{
    public class EmployeesController : Controller
    {
        private CmsContext db = new CmsContext();
        public ActionResult Index()
        {
            // 從資料庫讀取資料，建立model
            var emps = db.Employees.ToList();

            return View(emps);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // 以id 尋找員工資料
            Employee emp = db.Employees.Find(Id);
            if (emp == null)
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
        public ActionResult Create([Bind(Include ="Id, Name, Mobile, Email, Department, Title")] Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();

                return RedirectToAction("index");
            }

            return View(emp);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
        public ActionResult Edit([Bind(Include = "Id, Name, Mobile, Email, Department, Title")] Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return Content("查無此資料，請提供員工編號！");
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
        public ActionResult Delete(int Id)
        {
            Employee emp = db.Employees.Find(Id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}