using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternetShop.Models;
using System.Data.Entity;

namespace InternetShop.Models
{
    public class ItemRepository : IItemRepository
    {
        private Model1 _db = new Model1();

        public void AddItem(item item)
        {
            _db.items.Add(item);
            _db.SaveChanges();
        }

        public item GetItem(int? id)
        {
            item item = _db.items.Find(id);
            return item;

        }

        public IEnumerable<item> GetList()
        {
            return _db.items.Include(i => i.category);
        }

        public IEnumerable<category> GetCategoryList()
        {
            return _db.categories;
        }

        public void DeleteItem(int id)
        {
            item item = GetItem(id);
            _db.items.Remove(item);
            _db.SaveChanges();
        }

        public void SaveItem()
        {
            _db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        public void Dispose()
        {
            if (_db != null)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
}