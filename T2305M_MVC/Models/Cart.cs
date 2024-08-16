using System;
using T2305M_MVC.Entities;
namespace T2305M_MVC.Models
{
	public class Cart
	{
		public List<CartItem> CartItems { get; set; }

		public bool AddToCart(Product product, int buyQty)
		{
			if(CartItems == null)
			{
				CartItems = new List<CartItem>();
			}
			foreach(CartItem item in CartItems)
			{
				if(item.Id == product.Id)
				{
					item.BuyQty += buyQty;
					return true;
				}
			}
			CartItems.Add(new CartItem
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				BuyQty = buyQty
			}
			);
			return true;
		}
	}
}

