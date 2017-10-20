using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetShop.Models
{
    public class CartItem
    {
        public item Item { get; set; }
        public int Quantity { get; set; }
    }
}