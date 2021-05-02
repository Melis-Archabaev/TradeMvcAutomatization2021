using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "Максимуму 100 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}