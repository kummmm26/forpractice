﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using eCommerceWebApp.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebApp.Dal
{ 
	public class NewCartRepository : INewCartRepository
	{
		private readonly ECommerceDbContext _context;

		public NewCartRepository(ECommerceDbContext context)
		{
			_context = context;
		}

		public async Task<int> GenerateNewCart(int customerId)
		{
			var customerIdParameter = new SqlParameter()
			{
				ParameterName = "@p_CustomerId",
				SqlDbType = System.Data.SqlDbType.Int,
				Value = customerId
			};
			var cartIdParameter = new SqlParameter()
			{
				ParameterName = "@p_CartId",
				SqlDbType = System.Data.SqlDbType.Int,
				Direction = System.Data.ParameterDirection.Output
			};
			await _context.Database.ExecuteSqlRawAsync("EXEC GenerateNewCart  @p_CustomerId , @p_CartId OUTPUT", customerIdParameter, cartIdParameter);
			return Convert.ToInt32(cartIdParameter.Value);
		}

		
		public async Task<List<MyCartVM>> GetCartItems(int cartId)
		{
			var cartDetailQuery = from cart in _context.Carts
								  join
								  cartDetail in _context.CartDetails
								  on cart.CartId equals cartDetail.CartId
								  join
								  product in _context.Products
								  on cartDetail.ProductId equals product.ProductId
								  where cart.CartId == cartId
								  select new MyCartVM()
								  {
									  CartDetailId = cartDetail.CartId,
									  Discount = product.Discount,
									  ProductName = product.ProductName,
									  Quantity = cartDetail.Quantity,
									  Size = cartDetail.Size,
									  unitPrice = product.UnitPrice,
									  DiscountedAmount = product.UnitPrice - ((product.UnitPrice * product.Discount) / 100),
									  CartDate = cart.CartDate
								  };
			return await cartDetailQuery.ToListAsync();

			//return await _context.CartDetails.Where(cd => cd.CartId == cartId).ToListAsync();
		}

		

		
	}
}



