using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        IItemRepository rep;

        public CartController(IItemRepository r)
        {
            rep = r;
        }

        public ActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel {
                Cart = this.Cart,
                ReturnUrl = returnUrl
            });
        }

        // GET: Cart
        public ActionResult AddToCart(int id, string returnUrl)
        {
            item item = rep.GetItem(id);
            if (item != null)
            {
                Cart.AddItem(item, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult RemoveFromCart(int id, string returnUrl)
        {
            item item = rep.GetItem(id);
            if (item != null)
            {
                Cart.RemoveItem(item);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart Cart
        {
            get
            {
                Cart cart = (Cart)Session["Cart"];
                if (cart == null)
                {
                    cart = new Cart();
                    Session["Cart"] = cart;
                }
                return cart;
            }
        }
    }
}