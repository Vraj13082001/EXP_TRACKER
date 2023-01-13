using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcExpenseModel
    {
        public int ExpenseId { get; set; }
        [Required(ErrorMessage = "This Field is Required!!")]
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }

    }
}