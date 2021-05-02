using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6, ErrorMessage = "Максимуму 6 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string InvoiceTurnNumber { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60, ErrorMessage = "Максимуму 60 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string TaxAdministration { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Hour { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        //Deliveryman(Доставщик)
        public string Deliverer { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        //Recipient(Получатель)
        public string Recipient { get; set; }
        public ICollection<InvoicePen> InvoicePens { get; set; }
    }
}