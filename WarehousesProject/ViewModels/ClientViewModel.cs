using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousesProject.Services;
using WarehousesProject.Models;
using WarehousesProject.Commands;

namespace WarehousesProject.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Client> allClients;

        public ObservableCollection<Client> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
                onPropertyChanged("AllClients");
            }
        }

        private void onPropertyChanged(string _prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_prop));
        }

        private Client currentClient;

        public Client CurrentClient
        {
            get { return currentClient; }
            set
            {
                currentClient = value;
                onPropertyChanged("CurrentClient");
            }
        }

        public SystemCommands AddCommand { get; set; }
        public SystemCommands UpdateCommand { get; set; }

        private void addClient()
        {
            ClientService.addClient(currentClient);
            reloadData();
        }

        private void updateClient()
        {
            ClientService.updateClient(currentClient);
            reloadData();
        }

        private void reloadData()
        {
            AllClients = ClientService.getAll();
        }
        public ClientViewModel()
        {
            CurrentClient = new Client();
            AllClients = ClientService.getAll();
            AddCommand = new SystemCommands(addClient);
            UpdateCommand = new SystemCommands(updateClient);
        }
    }
}
