using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.Models.Entity;

namespace WebShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var items = db.ProductCategorys;
            return View(items);
        }


        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdateDate = DateTime.Now;
                model.Alias = WebShop.Models.Commons.Filter.FilterChar(model.Title);
                db.ProductCategorys.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}