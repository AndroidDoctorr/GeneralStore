using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }
        [Display(Name="Customer")]
        public string CustomerName { get; set; }
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Date")]
        public DateTimeOffset DateOfTransaction { get; set; }
    }
}