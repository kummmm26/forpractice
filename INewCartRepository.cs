using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceWebApp.Model;

namespace eCommerceWebApp.Dal
{
	public interface INewCartRepository
	{
		Task<int> GenerateNewCart(int customerId);
		Task<List<MyCartVM>> GetCartItems(int cartId);
		//public void RemoveFromCart (int productId);
		//decimal GetCartTotal();

	}
}
