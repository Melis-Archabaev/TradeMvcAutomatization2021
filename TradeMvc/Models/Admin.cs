using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10, ErrorMessage = "Максимуму 10 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string UserName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "Максимуму 20 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string Password { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Access { get; set; }
    }
}