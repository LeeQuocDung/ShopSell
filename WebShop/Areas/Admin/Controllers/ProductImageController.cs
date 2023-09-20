using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/PeoductImage
        public ActionResult Index(int id)
        {
            var items = db.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }
    }
}