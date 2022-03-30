using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousesProject.Models;

namespace WarehousesProject.Services
{
    public class ImportPermissionService
    {
        public static ObservableCollection<ImportPermission> getAll()
        {
            ObservableCollection<ImportPermission> permissions = new ObservableCollection<ImportPermission>();
            Model1 model = new Model1();
            foreach (ImportPermission permission in model.ImportPermissions)
            {
                permissions.Add(permission);
            }
            return permissions;
        }

        public static void addPermission(ImportPermission _permission)
        {
            Model1 model = new Model1();
            model.ImportPermissions.Add(_permission);
            model.SaveChanges();
        }

        //public static void updateClient(Client _client)
        //{
        //    Model1 model = new Model1();
        //    Client toBeUpdatedObj = model.Clients.Find(_client.Id);
        //    if (toBeUpdatedObj != null)
        //    {
        //        toBeUpdatedObj.Email = _client.Email;
        //        toBeUpdatedObj.Fax = _client.Fax;
        //        toBeUpdatedObj.Mobile = _client.Mobile;
        //        toBeUpdatedObj.Name = _client.Name;
        //        toBeUpdatedObj.Telephone = _client.Telephone;
        //        toBeUpdatedObj.Website = _client.Website;
        //        model.SaveChanges();
        //    }
        //}
    }
}
