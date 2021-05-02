using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class InvoicePen
    {
        [Key]
        public int InvoicePenId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "Максимуму 100 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string Desctiption { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public Invoice Invoices { get; set; }
    }
}