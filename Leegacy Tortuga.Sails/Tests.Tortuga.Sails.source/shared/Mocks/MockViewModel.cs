using System;
using System.Windows.Input;

namespace Tortuga.Sails.Tests.ViewModel
{

    public class MockViewModel : ViewModelBase
    {
        public ICommand Test
        {
            get { return Get<ICommand>("Test"); }
        }

        public DelegateCommand<T> InvokeGetCommandA<T>(string propertyName, Action<T> command)
        {

            return GetCommand<T>(command, propertyName);
        }

        public DelegateCommand<object> InvokeGetCommandB(string propertyName, Action<object> command)
        {
            return GetCommand(command, propertyName);
        }

        public DelegateCommand InvokeGetCommandC(string propertyName, Action command)
        {
            return GetCommand(command, propertyName);
        }

        public DelegateCommand<T> InvokeGetCommandD<T>(string propertyName, Action<T> command, Func<T, bool> canExecute)
        {
            return GetCommand<T>(command, canExecute, propertyName);
        }

        public DelegateCommand<object> InvokeGetCommandE(string propertyName, Action<object> command, Func<object, bool> canExecute)
        {
            return GetCommand(command, canExecute, propertyName);
        }

        public DelegateCommand InvokeGetCommandF(string propertyName, Action command, Func<bool> canExecute)
        {
            return GetCommand(command, canExecute, propertyName);
        }


    }
}
