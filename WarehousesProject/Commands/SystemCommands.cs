using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WarehousesProject.Commands
{
    public class SystemCommands : ICommand
    {
        Action myFun;

        public SystemCommands(Action _myfun)
        {
            myFun = _myfun;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myFun();
        }

        
    }
}
