using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeMvc.Models;
namespace TradeMvc.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var values = db.Departments.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department dp)
        {
            db.Departments.Add(dp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDelete(int id)
        {
            var values = db.Departments.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentBring(int id)
        {
            var values = db.Departments.Find(id);
            return View("DepartmentBring", values);
        }
        public ActionResult DepartmentUpdate(Department dprt)
        {
            var values = db.Departments.Find(dprt.DepartmentId);
            values.DepartmentName = dprt.DepartmentName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetails(int id)
        {
            var values = db.Personals.Where(x => x.DepartmentId == id).ToList();
            var dprt = db.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.dprtViewbag = dprt;
            return View(values);
        }
        public ActionResult DepartmentPersonalTrade(int id)
        {
            var values = db.TradeProccesses.Where(x => x.PersonalId == id).ToList();
            var PersonalName = db.Personals.Where(x => x.PersonalId == id).Select(y => y.PersonalName + y.PersonalLastName).FirstOrDefault();
            ViewBag.DepPerson = PersonalName;
            return View(values);
        }
    }
}