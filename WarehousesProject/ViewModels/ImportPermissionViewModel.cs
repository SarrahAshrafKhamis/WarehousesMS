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
    public class ImportPermissionViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ImportPermission> allPermissions;

        public ObservableCollection<ImportPermission> AllPermissions
        {
            get { return allPermissions; }
            set
            {
                allPermissions = value;
                onPropertyChanged("AllPermissions");
            }
        }

        private void onPropertyChanged(string _prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_prop));
        }

        private ImportPermission currentPermission;

        public ImportPermission CurrentPermission
        {
            get { return currentPermission; }
            set
            {
                currentPermission = value;
                onPropertyChanged("CurrentPermission");
            }
        }

        public SystemCommands AddCommand { get; set; }
        public SystemCommands UpdateCommand { get; set; }

        private void addImportPermission()
        {
            ImportPermissionService.addPermission(currentPermission);
            reloadData();
        }

        //private void updateImportPermission()
        //{
        //    ImportPermissionService.updateImportPermission(currentImportPermission);
        //    reloadData();
        //}

        private void reloadData()
        {
            AllPermissions = ImportPermissionService.getAll();
        }
        public ImportPermissionViewModel()
        {
            CurrentPermission = new ImportPermission();
            AllPermissions = ImportPermissionService.getAll();
            AddCommand = new SystemCommands(addImportPermission);
            //UpdateCommand = new SystemCommands(updateImportPermission);
        }
    }
}
