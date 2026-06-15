using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Budget_Planner_Alnur_Madiyev_w68646.Core
{
    class RelayCommand : ICommand // call ICommand methods 
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;
        private DependencyObject sender;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        private bool IsValid(DependencyObject obj)
        {
            if (obj != null)
            {
                return !Validation.GetHasError(obj) && LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>().All(IsValid);
            }
            return true;

        }

        public bool CanExecute(object parameter)
        {
            bool valid = IsValid(sender as DependencyObject);
            return valid;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

    }



}
