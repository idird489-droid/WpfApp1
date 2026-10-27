using System;
using System.Windows.Input;

namespace WpfApp1
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _executer;
        private readonly Func<object?, bool>? _peutExecuter;

        public RelayCommand(
            Action<object?> executer,
            Func<object?, bool>? peutExecuter = null)
        {
            _executer = executer
                ?? throw new ArgumentNullException(nameof(executer));

            _peutExecuter = peutExecuter;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parametre)
        {
            return _peutExecuter == null || _peutExecuter(parametre);
        }

        public void Execute(object? parametre)
        {
            _executer(parametre);
        }
    }
}