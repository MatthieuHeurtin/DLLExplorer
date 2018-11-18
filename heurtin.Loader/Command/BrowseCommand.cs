using System;
using System.Windows.Input;

namespace heurtin.Loader.Command
{
    public class BrowseCommand : ICommand
    {

        private Action _action;
        private bool _canExecute;

        public BrowseCommand(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }

    }
}
