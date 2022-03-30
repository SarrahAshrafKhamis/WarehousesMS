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
    public class WareHouseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Warhouse> allwareHouses;

        public ObservableCollection<Warhouse> AllWareHouses
        {
            get { return allwareHouses; }
            set 
            { 
                allwareHouses = value;
                onPropertyChanged("AllWareHouses");
            }
        }

        private Warhouse currentWareHouse;

        public Warhouse CurrentWareHouse
        {
            get { return currentWareHouse; }
            set 
            { 
                currentWareHouse = value;
                onPropertyChanged("CurrentWareHouse");
            }
        }

        public SystemCommands AddCommand { get; set; }

        public SystemCommands UpdateCommand { get; set; }


        private void onPropertyChanged(string _prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_prop));
        }

        public WareHouseViewModel()
        {
            currentWareHouse = new Warhouse();
            AllWareHouses = WareHouseService.getAll();
            AddCommand = new SystemCommands(this.addWareHouse);
            UpdateCommand = new SystemCommands(this.updateWareHouse); 

        }

        private void addWareHouse()
        {
            WareHouseService.addWarehouse(currentWareHouse);
            reloadData();
        }

        private void updateWareHouse()
        {
            WareHouseService.updateWarehouse(currentWareHouse);
            reloadData();
        }

        private void reloadData()
        {
           AllWareHouses = WareHouseService.getAll();
        }


    }
}
