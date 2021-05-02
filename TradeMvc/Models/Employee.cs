using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Максимум 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="Максимуму 30 символов")]
        [Required(ErrorMessage ="Это поля не должно быть пустой")]
        public string EmployeeLastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string EmployeeCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="Максимуму 30 символов")]
        [Required(ErrorMessage = "Это поля не должно быть пустой")]
        public string EmployeeMail { get; set; }
        public bool Status { get; set; }
        public ICollection<TradeProccess> TradeProccesses { get; set; }
    }
}