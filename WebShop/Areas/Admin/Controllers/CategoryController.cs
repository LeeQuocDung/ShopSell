using System;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.Models.Entity;

namespace WebShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Catagory
        public ActionResult Index()
        {
            var items = db.Categories;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdateDate = DateTime.Now;
                model.Alias = WebShop.Models.Commons.Filter.ChuyenCoDauThanhKhongDau(model.Title);
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var item = db.Categories.Find(Id);
            return View(item);

            // Lấy đối tượng Category từ cơ sở dữ liệu
            //Category category = db.Categories.Find(Id);

            //// Sử dụng AutoMapper để ánh xạ Category sang CategoryViewModel
            //CategoryViewModel viewModel = Mapper.Map<CategoryViewModel>(category);

            //if (viewModel == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(model);
                model.UpdateDate = DateTime.Now;
                model.Alias = WebShop.Models.Commons.Filter.FilterChar(model.Title);
                db.Entry(model).Property(x => x.Title).IsModified = true;
                db.Entry(model).Property(x => x.Desciption).IsModified = true;
                db.Entry(model).Property(x => x.Alias).IsModified = true;
                db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                db.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                db.Entry(model).Property(x => x.Postion).IsModified = true;
                db.Entry(model).Property(x => x.UpdateBy).IsModified = true;
                db.Entry(model).Property(x => x.UpdateDate).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Categories.Find(id);
            if(item != null)
            {
                var DeleteItem = db.Categories.Attach(item);
                db.Categories.Remove(DeleteItem);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}