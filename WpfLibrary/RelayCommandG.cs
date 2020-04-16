using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfLibrary
{
    public class RelayCommandG<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        private Func<bool> _CanExecute;
        private Action<T> _Execute;
        public RelayCommandG(Action<T> execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            this._CanExecute = canExecute;
            this._Execute = execute;
        } 
        public RelayCommandG(Action<T> execute) : this(execute, null)
        {

        }
        public bool CanExecute(object parameter)
        {
            if (this._CanExecute == null)
            {
                return true;
            }
            return this._CanExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            this._Execute.Invoke((T)parameter);
        }

    }
}

