using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeMvc.Models;

namespace TradeMvc.Controllers
{
    public class ProductController : Controller
    {
        
        AppDbContext db = new AppDbContext();
        // GET: Product 
        public ActionResult Index()
        {
            var values = db.Products.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.vls = values;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var values = db.Products.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductBring(int id)
        {
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.vls = values;
            var values2 = db.Products.Find(id);
            return View("ProductBring", values2);
        }
        public ActionResult ProductUpdate(Product p)
        {
            var values = db.Products.Find(p.ProductId);
            values.BuyPrice = p.BuyPrice;
            values.Status = p.Status;
            values.CategoryId = p.CategoryId;
            values.Mark = p.Mark;
            values.SalePrice = p.SalePrice;
            values.Stock = p.Stock;
            values.ProductName = p.ProductName;
            values.ProductImage = p.ProductImage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}