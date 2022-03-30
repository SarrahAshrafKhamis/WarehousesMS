using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousesProject.Models;

namespace WarehousesProject.Services
{
    public class WareHouseService
    {
        public static ObservableCollection<Warhouse> getAll()
        {
            ObservableCollection<Warhouse> wareHouses = new ObservableCollection<Warhouse>();
            Model1 model = new Model1();
            foreach(Warhouse warehouse in model.Warhouses)
            {
                wareHouses.Add(warehouse);
            }
            return wareHouses;
        }

        public static void addWarehouse(Warhouse _warhouse)
        {
            Model1 model = new Model1();
            model.Warhouses.Add(_warhouse);
            model.SaveChanges();
        }

        public static void updateWarehouse(Warhouse _warhouse)
        {
            Model1 model = new Model1();
            Warhouse toBeUpdatedObj = model.Warhouses.Find(_warhouse.Name);
            if (toBeUpdatedObj != null)
            {
                toBeUpdatedObj.Address = _warhouse.Address;
                toBeUpdatedObj.Responsible = _warhouse.Responsible;
                model.SaveChanges();
            }
        }

    }
}
