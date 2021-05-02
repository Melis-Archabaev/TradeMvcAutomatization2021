using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}