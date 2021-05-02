using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeMvc.Models;
namespace TradeMvc.Controllers
{
    public class EmployeeController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            var values = db.Employees.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employee e)
        {
            e.Status = true;
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var values = db.Employees.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeBring(int id)
        {
            var values = db.Employees.Find(id);
            return View("EmployeeBring", values);
        }
        public ActionResult EmployeeUpdate(Employee e)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeBring");
            }
            var values = db.Employees.Find(e.EmployeeId);
            values.EmployeeName = e.EmployeeName;
            values.EmployeeLastName = e.EmployeeLastName;
            values.EmployeeCity = e.EmployeeCity;
            values.EmployeeMail = e.EmployeeMail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TradeEmployee(int id)
        {
            var values = db.TradeProccesses.Where(x => x.EmployeeId == id).ToList();
            var EmpNames = db.Employees.Where(x => x.EmployeeId == id).Select(y => y.EmployeeName + " " + y.EmployeeLastName).FirstOrDefault();
            ViewBag.EmpName = EmpNames;
            return View(values);
        }
    }
}