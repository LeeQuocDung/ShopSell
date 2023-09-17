using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Entity
{
    [Table("tbl_Oder")]
    public class Oder:CommonAbstract
    {
        public Oder()
        {
            this.OderDetails = new HashSet<OderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Adderss { get; set; }
        public decimal TotalAmount { get; set; }
        public string Quantity { get; set; }

        public ICollection<OderDetail> OderDetails { get; set; }
    }
}