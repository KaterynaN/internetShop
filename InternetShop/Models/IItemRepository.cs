using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Models;

namespace InternetShop.Models
{
    public interface IItemRepository
    {
        IEnumerable<item> GetList();
        item GetItem(int? id);
        void AddItem(item item);
        IEnumerable<category> GetCategoryList();
        void DeleteItem(int id);
        void SaveItem();
    }
}
