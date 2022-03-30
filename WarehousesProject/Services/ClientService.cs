using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousesProject.Models;

namespace WarehousesProject.Services
{
    public class ClientService
    {
        public static ObservableCollection<Client> getAll()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            Model1 model = new Model1();
            foreach (Client client in model.Clients)
            {
                clients.Add(client);
            }
            return clients;
        }

        public static void addClient(Client _client)
        {
            Model1 model = new Model1();
            model.Clients.Add(_client);
            model.SaveChanges();
        }

        public static void updateClient(Client _client)
        {
            Model1 model = new Model1();
            Client toBeUpdatedObj = model.Clients.Find(_client.Id);
            if (toBeUpdatedObj != null)
            {
                toBeUpdatedObj.Email = _client.Email;
                toBeUpdatedObj.Fax = _client.Fax;
                toBeUpdatedObj.Mobile = _client.Mobile;
                toBeUpdatedObj.Name = _client.Name;
                toBeUpdatedObj.Telephone = _client.Telephone;
                toBeUpdatedObj.Website = _client.Website;
                model.SaveChanges();
            }
        }
    }
}
