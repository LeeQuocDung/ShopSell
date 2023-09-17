using System;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.Models.Entity;
using WebShop.Models.ViewModel;

namespace WebShop.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            var item = db.News.OrderByDescending(x => x.Id).ToList();
            return View(item);
        } 
        
        public ActionResult Add()
        {
            var items = db.Categories.ToList();
            var viewModel = new CategoryNewViewModel
            {
                NewInfo = new New(),
                Categories = items
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryNewViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.NewInfo.CreateDate = DateTime.Now;
                model.NewInfo.UpdateDate = DateTime.Now;
                model.NewInfo.Alias = WebShop.Models.Commons.Filter.FilterChar(model.NewInfo.Title);
                db.News.Add(model.NewInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var item = db.News.Find(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            var items = db.Categories.ToList();
            var viewModel = new CategoryNewViewModel
            {
                NewInfo = item,
                Categories = items
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryNewViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.NewInfo.UpdateDate = DateTime.Now;
                model.NewInfo.Alias = WebShop.Models.Commons.Filter.FilterChar(model.NewInfo.Title);
                db.News.Attach(model.NewInfo);
                db.Entry(model.NewInfo).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.News.Find(id);
            if(item != null)
            {
                db.News.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.News.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true ,isActive = item.IsActive});

            }
            return Json(new { success = false });
        }

        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if(items != null && items.Any())
                {
                    foreach(var item in items)
                    {
                        var obj = db.News.Find(Convert.ToInt32(item));
                        db.News.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}