using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradeMvc.Controllers
{
    public class InvoiceController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Invoice
        public ActionResult Index()
        {
            var values = db.Invoices.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewInvoice(Invoice p)
        {
            db.Invoices.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetInvoice(int id)
        {
            var values = db.Invoices.Find(id);
            return View("GetInvoice", values);
        }
        public ActionResult InvoiceUpdate(Invoice p)
        {
            var values = db.Invoices.Find(p.InvoiceId);
            values.InvoiceSerialNumber = p.InvoiceSerialNumber;
            values.InvoiceTurnNumber = p.InvoiceTurnNumber;
            values.TaxAdministration = p.TaxAdministration;
            values.InvoiceDateTime = p.InvoiceDateTime;
            values.Deliverer = p.Deliverer;
            values.GetDelivery = p.GetDelivery;
            values.Total = p.Total;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult InvoiceDetails(int id)
        {
            var values = db.InvoicePens.Where(x => x.InvoiceId == id).ToList();
            return View(values);
        }
    }
}