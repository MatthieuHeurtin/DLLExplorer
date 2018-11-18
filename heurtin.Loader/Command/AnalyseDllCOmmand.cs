using System;
using System.Windows.Input;

namespace heurtin.Loader.Command
{
    public class AnalyseDllCommand : ICommand
    {
        private Action<string> _action;
        private bool _canExecute;

        public event EventHandler CanExecuteChanged;

        public AnalyseDllCommand(Action<string> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;

        }

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
