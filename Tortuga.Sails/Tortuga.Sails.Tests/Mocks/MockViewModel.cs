using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tortuga.Sails.Tests.ViewModel
{
    public class MockViewModel : ViewModelBase
    {
        public ICommand AsyncGCommand => GetCommand(AsyncG);

        public ICommand AsyncHCommand => GetCommand(AsyncH);

        public ICommand AsyncICommand => GetCommand<int>(AsyncI);

        public ICommand Test
        {
            get { return Get<ICommand>("Test"); }
        }

        public async Task AsyncG()
        {
            await Task.Delay(1);
        }

        public async Task<int> AsyncH()
        {
            await Task.Delay(1); return 1;
        }

        public async Task<long> AsyncI(int echo)
        {
            await Task.Delay(1); return echo;
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
