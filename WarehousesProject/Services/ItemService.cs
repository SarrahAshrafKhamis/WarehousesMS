using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousesProject.Models;

namespace WarehousesProject.Services
{
    public class ItemService
    {
        public static ObservableCollection<Item> getAll()
        {
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            Model1 model = new Model1();
            foreach (Item item in model.Items)
            {
                items.Add(item);
            }
            return items;
        }

        public static void addItem(Item _Item)
        {
            Model1 model = new Model1();
            model.Items.Add(_Item);
            model.SaveChanges();
        }

        public static void updateItem(Item _Item)
        {
            Model1 model = new Model1();
            Item toBeUpdatedObj = model.Items.Find(_Item.Code);
            if (toBeUpdatedObj != null)
            {
                toBeUpdatedObj.Name = _Item.Name;
                model.SaveChanges();
            }
        }

    }
}
