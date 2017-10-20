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
                orderItem.Quantity += quantity;
            }
        }

        public void RemoveItem(item item)
        {
            cartItems.RemoveAll(ci => ci.Item.id == item.id);
        }

        public decimal TotalSum()
        {
            return cartItems.Sum(ci => ci.Item.price * ci.Quantity);
        }

        public void Clear()
        {
            cartItems.Clear();
        }

        public IEnumerable<CartItem> Items
        {
            get
            {
                return cartItems;
            }
        }
    }
}