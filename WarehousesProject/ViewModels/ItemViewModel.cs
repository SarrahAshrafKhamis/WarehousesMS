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
    public class ItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Item> allItems;

        public ObservableCollection<Item> AllItems
        {
            get { return allItems; }
            set
            {
                allItems= value;
                onPropertyChanged("AllItems");
            }
        }

        private Item currentItem;

        public Item CurrentItem
        {
            get { return currentItem; }
            set
            {
                currentItem = value;
                onPropertyChanged("CurrentItem");
                currentMeasureUnit.ItemCode = currentItem.Code;
            }
        }

        private Item_MeasureUnit currentMeasureUnit;

        public Item_MeasureUnit CurrentMeasureUnit
        {
            get { return currentMeasureUnit; }
            set
            {
                currentMeasureUnit = value;
                onPropertyChanged("CurrentMeasureUnit");
            }
        }

        private ObservableCollection<Item_MeasureUnit> currentItemMeasureUnits;

        public ObservableCollection<Item_MeasureUnit> CurrentItemMeasureUnits
        {
            get { return currentItemMeasureUnits; }
            set 
            { 
                currentItemMeasureUnits = value;
                onPropertyChanged("CurrentItemMeasureUnits");
            }
        }


        public SystemCommands AddCommand { get; set; }

        public SystemCommands UpdateCommand { get; set; }
        public SystemCommands AddMeasureunitCommand { get; set; }


        private void onPropertyChanged(string _prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_prop));
        }

        public ItemViewModel()
        {
            currentItem = new Item();
            currentMeasureUnit= new Item_MeasureUnit();
            currentMeasureUnit.ItemCode = currentItem.Code;
            currentItemMeasureUnits = new ObservableCollection<Item_MeasureUnit>();
            AllItems = ItemService.getAll();
            AddCommand = new SystemCommands(addItem);
            UpdateCommand = new SystemCommands(updateItem);
            AddMeasureunitCommand= new SystemCommands(addMeasureUnit);
        }

        private void addMeasureUnit()
        {
            Item_MeasureUnit newItemMeasureUnit = new Item_MeasureUnit();
            newItemMeasureUnit.ItemCode = currentItem.Code;
            newItemMeasureUnit.MeasureUnit = CurrentMeasureUnit.MeasureUnit;
            currentItemMeasureUnits.Add(newItemMeasureUnit);
            currentMeasureUnit.MeasureUnit = "";
        }

        private void addItem()
        {
            ItemService.addItem(currentItem);
            ItemMeasureUnitService.addItemMeasureUnits(currentItemMeasureUnits);
            reloadData();
        }

        private void updateItem()
        {
            ItemService.updateItem(currentItem);
            reloadData();
        }

        private void reloadData()
        {
            AllItems = ItemService.getAll();
        }


    }
}
