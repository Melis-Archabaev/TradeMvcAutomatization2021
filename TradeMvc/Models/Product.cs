using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string Mark { get; set; }
        public short Stock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "Максимуму 250 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string ProductImage { get; set; }
        //Myself add CategoryId
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<TradeProccess> TradeProccess { get; set; }
    }
}