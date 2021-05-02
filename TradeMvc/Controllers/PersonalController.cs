using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeMvc.Models;

namespace TradeMvc.Controllers
{
    public class PersonalController : Controller
    {
        AppDbContext db = new AppDbContext();

        // GET: Personal
        public ActionResult Index()
        {
            var values = db.Personals.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult PersonalAdd()
        {
            List<SelectListItem> values = (from x in db.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vls = values;
            return View();
        }
        [HttpPost]
        public ActionResult PersonalAdd(Personal p)
        {
            db.Personals.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonalBring(int id)
        {
            List<SelectListItem> values = (from x in db.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vls = values;
            var valuesTwo = db.Personals.Find(id);
            return View("PersonalBring", valuesTwo);
        }
        public ActionResult PersonalUpdate(Personal p)
        {
            var values = db.Personals.Find(p.PersonalId);
            values.PersonalName = p.PersonalName;
            values.PersonalLastName = p.PersonalLastName;
            values.PersonalView = p.PersonalView;
            values.DepartmentId = p.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}