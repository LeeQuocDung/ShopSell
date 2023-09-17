using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Entity
{
    [Table("tbl_Category")]
    public class Category : CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<New>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống!")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Desciption { get; set; }
        public int Postion { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }

        public ICollection<New> News { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}