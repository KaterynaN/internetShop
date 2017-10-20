using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternetShop.Models;

namespace InternetShop.Controllers
{
    public class itemsController : Controller
    {
        IItemRepository rep;

        public itemsController(IItemRepository r)
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

        // GET: items/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(rep.GetCategoryList(), "id", "name");
            return View();
        }

        // POST: items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,category_id,price,quantity")] item item, 
            HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    var fileName = System.IO.Path.GetFileName(uploadImage.FileName);
                    item.image_url = fileName;
                    uploadImage.SaveAs(Server.MapPath("~/Images/" + item.image_url));
                }
                rep.AddItem(item);
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(rep.GetCategoryList(), "id", "name", item.category_id);
            return View(item);
        }

        // GET: items/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.category_id = new SelectList(rep.GetCategoryList(), "id", "name", item.category_id);
            return View(item);
        }

        // POST: items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,category_id,price,quantity")] item item,
            HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                var foundItem = rep.GetItem(item.id);
                if(uploadImage != null)
                {
                    var fileName = System.IO.Path.GetFileName(uploadImage.FileName);
                    foundItem.image_url = fileName;
                    uploadImage.SaveAs(Server.MapPath("~/Images/" + foundItem.image_url));
                }
                else
                {
                    foundItem.image_url = rep.GetItem(item.id).image_url;
                }
                foundItem.name = item.name;
                foundItem.category = item.category;
                foundItem.category_id = item.category_id;
                foundItem.description = item.description;
                foundItem.order_item = item.order_item;
                foundItem.price = item.price;
                foundItem.quantity = item.quantity;
                
                //db.Entry(item).State = EntityState.Modified;
                rep.SaveItem();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(rep.GetCategoryList(), "id", "name", item.category_id);
            return View(item);
        }

        // GET: items/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.DeleteItem(id);
            return RedirectToAction("Index");
        }   
    }
}
