using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        IItemRepository rep;

        public HomeController(IItemRepository r)
        {
            rep = r;
        }

        // GET: items
        public ActionResult Index()
        {
            return View(rep.GetList().ToList());
        }

        // GET: items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item item = rep.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
    }
}