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
    public class ImporterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Importer> allImporters;

        public ObservableCollection<Importer> AllImporters
        {
            get { return allImporters; }
            set
            {
                allImporters = value;
                onPropertyChanged("AllImporters");
            }
        }

        private void onPropertyChanged(string _prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_prop));
        }

        private Importer currentImporter;

        public Importer CurrentImporter
        {
            get { return currentImporter; }
            set 
            {
                currentImporter = value;
                onPropertyChanged("CurrentImporter");
            }
        }

        public SystemCommands AddCommand { get; set; }
        public SystemCommands UpdateCommand { get; set; }

        private void addImporter()
        {
            ImporterService.addImporter(currentImporter);
            reloadData();
        }

        private void updateImporter()
        {
            ImporterService.updateImporter(currentImporter);
            reloadData();
        }

        private void reloadData()
        {
            AllImporters = ImporterService.getAll();
        }
        public ImporterViewModel()
        {
            CurrentImporter = new Importer();
            AllImporters = ImporterService.getAll();
            AddCommand = new SystemCommands(addImporter);
            UpdateCommand = new SystemCommands(updateImporter);
        }
    }
}
