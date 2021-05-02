using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeMvc.Models
{
    public class TradeProccess
    {
        [Key]
        public int TradeId { get; set; }
        public DateTime DateTimeTrade { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public int PersonalId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
        public  virtual Personal Personal { get; set; }
    }
}