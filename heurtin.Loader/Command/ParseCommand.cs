using System;
using System.Windows.Input;

namespace heurtin.Loader.Command
{
    public class ParseCommand : ICommand
    {
        private Action<string> _action;
        private bool _canExecute;

        public ParseCommand(Action<string> action, bool canExecute)
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
            _action(parameter as string);
        }
    }
}
