using System;
using System.Windows.Input;

namespace OOP_Lab_3
{
    public class MyICommand<T> : ICommand
    {
        Action<T> _TargetExecuteMethod; 
        Func<T, bool> _TargetCanExecuteMethod;
		
        public MyICommand(Action<T> executeMethod) {
            _TargetExecuteMethod = executeMethod; 
        }
		
        public MyICommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod) {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod; 
        }

        public void RaiseCanExecuteChanged() {
            CanExecuteChanged(this, EventArgs.Empty); 
        } 
		
        #region ICommand Members

        bool ICommand.CanExecute(object parameter) { 
		
            if (_TargetCanExecuteMethod != null) { 
                var tparam = (T)parameter; 
                return _TargetCanExecuteMethod(tparam); 
            } 
			
            return _TargetExecuteMethod != null;
        }

        public event EventHandler CanExecuteChanged = delegate { };
	
        void ICommand.Execute(object parameter)
        {
            _TargetExecuteMethod?.Invoke((T)parameter);
        } 
		
        #endregion 
    }
}