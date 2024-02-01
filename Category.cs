﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWebApp.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is a required field!")]
        [MaxLength(50, ErrorMessage = "Catgeory name can not be more than 50 characters!")]
        public string CategoryName { get; set; } = string.Empty;
        [MaxLength(200, ErrorMessage = "Catgeory description can not be more than 200 characters!")]
        public string? CategoryDescription { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
