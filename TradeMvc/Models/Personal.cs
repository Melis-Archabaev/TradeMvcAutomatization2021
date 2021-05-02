using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string PersonalName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string PersonalLastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "Максимуму 250 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string PersonalView { get; set; }

        public ICollection<TradeProccess> TradeProccesses { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}