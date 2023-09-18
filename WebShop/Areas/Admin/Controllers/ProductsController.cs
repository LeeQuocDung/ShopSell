﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.Models.Entity;

namespace WebShop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x=>x.Id);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            //if (!string.IsNullOrEmpty(SearchText))
            //{
            //    items = items.Where(x => x.Alias.Contains(SearchText) || x.Title.Contains(SearchText)).ToList();
            //}
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.ProductCatgory = new SelectList(db.ProductCategorys.ToList(), "Id", "Title");
            return View();
        }
    }
}