using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeMvc.Models;

namespace TradeMvc.Controllers
{
    public class SaleController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Sale
        public ActionResult Index()
        {
            var values = db.TradeProccesses.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            List<SelectListItem> values = (from x in db.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            ViewBag.vls = values;

            List<SelectListItem> values2 = (from x in db.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName+ " " +x.EmployeeLastName ,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();
            ViewBag.vls2 = values2;

            List<SelectListItem> values3 = (from x in db.Personals.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonalName + " " +x.PersonalLastName,
                                               Value = x.PersonalId.ToString()
                                           }).ToList();
            ViewBag.vls3 = values3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(TradeProccess t)
        {
            t.DateTimeTrade = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TradeProccesses.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleGet(int id)
        {
            var values = db.TradeProccesses.Find(id);
            return View("SaleGet", id);
        }
    }
}