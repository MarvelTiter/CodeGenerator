using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeGenerator.Core
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> action;
        private readonly Func<T, bool> canExecute;
        private bool _IsExecuting = false;

        public RelayCommand(Action<T> action, Func<T, bool> canExecute)
        {
            this.action = action ?? throw new ArgumentException($"Action不能为空");
            this.canExecute = canExecute;
        }
        public RelayCommand(Action<T> action) : this(action, null) { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (action != null)
            {
                var executeCheck = canExecute?.Invoke((T)parameter);
                if (executeCheck.HasValue)
                    return !_IsExecuting && executeCheck.HasValue && executeCheck.Value;
                return !_IsExecuting;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _IsExecuting = true;
            try
            {
                RaiseCanExecuteChanged();
                action?.Invoke((T)parameter);
            }
            finally
            {
                _IsExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        private void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action action)
            : base(_ => action(), null) { }
        public RelayCommand(Action action, Func<bool> canExecute)
            : base(_ => action(), _ => canExecute()) { }
    }
}
