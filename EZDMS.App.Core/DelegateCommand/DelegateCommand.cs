//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EZDMS.App.Core
//{
//    public class DelegateCommand : System.Windows.Input.ICommand
//    {
//        private readonly Predicate<object> _canExecute;
//#pragma warning disable IDE1006 // Naming Styles
//        private readonly Action<object> _execute;
//#pragma warning restore IDE1006 // Naming Styles

//        public DelegateCommand(Action<object> execute)
//          : this(execute, null)
//        {
//        }

//        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
//        {
//            _execute = execute;
//            _canExecute = canExecute;
//        }

//        public bool CanExecute(object parameter)
//        {
//            if (_canExecute == null)
//                return true;

//            return _canExecute(parameter);
//        }

//        public void Execute(object parameter)
//        {
//            _execute(parameter);
//        }

//        public event EventHandler CanExecuteChanged;
//    }
//}
