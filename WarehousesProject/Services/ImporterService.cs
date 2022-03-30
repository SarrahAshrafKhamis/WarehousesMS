using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousesProject.Models;

namespace WarehousesProject.Services
{
    public class ImporterService
    {
        public static ObservableCollection<Importer> getAll()
        {
            ObservableCollection<Importer> importers = new ObservableCollection<Importer>();
            Model1 model = new Model1();
            foreach (Importer importer in model.Importers)
            {
                importers.Add(importer);
            }
            return importers;
        }

        public static void addImporter(Importer _importer)
        {
            Model1 model = new Model1();
            model.Importers.Add(_importer);
            model.SaveChanges();
        }

        public static void updateImporter(Importer _importer)
        {
            Model1 model = new Model1();
            Importer toBeUpdatedObj = model.Importers.Find(_importer.Id);
            if (toBeUpdatedObj != null)
            {
                toBeUpdatedObj.Email = _importer.Email;
                toBeUpdatedObj.Fax = _importer.Fax;
                toBeUpdatedObj.Mobile = _importer.Mobile;
                toBeUpdatedObj.Name = _importer.Name;
                toBeUpdatedObj.Telephone = _importer.Telephone;
                toBeUpdatedObj.Website = _importer.Website;
                model.SaveChanges();
            }
        }
    }
}
