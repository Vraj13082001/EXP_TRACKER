using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcCategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "This Field is Required!!")]
        public string CategorryName { get; set; }
        public decimal CategoryLimit { get; set; }
    }
}