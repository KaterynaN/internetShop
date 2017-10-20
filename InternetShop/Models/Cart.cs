using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetShop.Models
{
    public class Cart
    {
        List<CartItem> cartItems = new List<CartItem>();

        public void AddItem(item item, int quantity)
        {
            CartItem orderItem = cartItems
                .Where(ci => ci.Item.id == item.id)
                .FirstOrDefault();

            if(orderItem == null)
            {
                cartItems.Add(new CartItem()
                {
                    Item = item,
                    Quantity = quantity

                });
            }
            else
            {

            }
        }
    }
}