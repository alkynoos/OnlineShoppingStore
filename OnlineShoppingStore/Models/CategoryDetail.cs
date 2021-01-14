using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class CategoryDetail
    {
        
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category Name Requird")]
        [StringLength(100, ErrorMessage = "From 3 to 100 characters are allowed", MinimumLength = 3)] 
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}