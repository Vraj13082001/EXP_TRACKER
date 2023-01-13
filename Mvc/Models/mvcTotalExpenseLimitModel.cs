using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcTotalExpenseLimit
    {
        public int TotalExpenseId { get; set; }
        [Required(ErrorMessage = "This Field is Required!!")]
        public int TotalExpenseLimit1 { get; set; }
    }
}