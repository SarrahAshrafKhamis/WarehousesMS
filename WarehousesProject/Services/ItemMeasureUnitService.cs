using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousesProject.Models;

namespace WarehousesProject.Services
{
    public class ItemMeasureUnitService
    {
        public static void addItemMeasureUnits(ObservableCollection<Item_MeasureUnit> _measureUnits)
        {
            Model1 model = new Model1();
            foreach(Item_MeasureUnit measureUnit in _measureUnits)
            {
                model.Item_MeasureUnit.Add(measureUnit);
            }
            model.SaveChanges();
        }
    }
}
