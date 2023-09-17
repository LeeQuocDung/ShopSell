using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Entity
{
    [Table("tbl_OderDetail")]
    public class OderDetail
    {
        [Key]
        [Column(Order = 0)]
        public int OderId { get; set; }
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Oder Oder { get; set; }
        public virtual Product Product { get; set; }
    }
}