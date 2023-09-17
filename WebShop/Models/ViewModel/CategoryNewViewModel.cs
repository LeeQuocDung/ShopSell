using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models.Entity;

namespace WebShop.Models.ViewModel
{
    public class CategoryNewViewModel 
    {
        public New NewInfo { get; set; }

        public List<Category> Categories { get; set; }
    }
}