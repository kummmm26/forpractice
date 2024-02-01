using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWebApp.Model
{
	public class MyCartVM
	{
        public int CartDetailId { get; set; }
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double  unitPrice { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public int Discount { get; set; }
        public  double DiscountedAmount { get; set; }
        public DateTime CartDate { get; set; }
        public string? Picture { get; set;}
    }
}
