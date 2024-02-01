using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWebApp.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer name is a required field!")]
        [MaxLength(100, ErrorMessage = "Customer name can not exceed 100 characters!")]
        public string ContactName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Customer address is a required field!")]
        [MaxLength(500, ErrorMessage = "Customer address can not exceed 500 characters!")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is a required field!")]
        [MaxLength(100, ErrorMessage = "City name can not exceed 100 characters!")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is a required field!")]
        [MaxLength(100, ErrorMessage = "Email Id can not exceed 100 characters!")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Id!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone Number is a required field!")]
        [MaxLength(20, ErrorMessage = "Phone can not exceed 20 characters!")]
        public string Phone { get; set; } = string.Empty;
        //Navigation Property
        public virtual ICollection<Cart>? Carts { get; set; }
    }
}
