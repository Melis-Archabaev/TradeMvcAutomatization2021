using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeMvc.Models;

namespace TradeMvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public AppDbContext db = new AppDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var values = db.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category k)
        {
            db.Categories.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var ctgr = db.Categories.Find(id);
            db.Categories.Remove(ctgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int id)
        {
            var kategori = db.Categories.Find(id);
            return View("CategoryBring", kategori);
        }
        public ActionResult CategoryUpdate(Category ct)
        {
            var ctgr = db.Categories.Find(ct.CategoryId);
            ctgr.CategoryName = ct.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}