using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;

namespace Tortuga.Sails.Tests.Commands
{
    [TestClass]
    public class DelegateCommand1Tests
    {
        [TestMethod]
        public void DelegateCommand_CanExecute()
        {
            var callCount = 0;
            var x = new DelegateCommand<string>(p => callCount++, p => true);
            Assert.AreEqual(true, x.CanExecute(""));
            x.Execute("");
            Assert.AreEqual(1, callCount);

            var y = (ICommand)x;
            Assert.AreEqual(true, y.CanExecute(""));
            y.Execute("");
            Assert.AreEqual(2, callCount);
        }

        [TestMethod]
        public void DelegateCommand_CanExecute2()
        {
            var callCount = 0;
            var x = new DelegateCommand<string>(p => callCount++);
            Assert.AreEqual(true, x.CanExecute(""));
            x.Execute("");
            Assert.AreEqual(1, callCount);

            var y = (ICommand)x;
            Assert.AreEqual(true, y.CanExecute(""));
            y.Execute("");
            Assert.AreEqual(2, callCount);
        }

        [TestMethod]
        public void DelegateCommand_Create()
        {
            var callCount = 0;
            Action<string> execute = p => callCount++;
            Func<string, bool> canExecute = p => true;

            var x = DelegateCommand.Create(execute, canExecute);
            Assert.AreEqual(true, x.CanExecute(""));
            x.Execute("");
            Assert.AreEqual(1, callCount);

            var y = (ICommand)x;
            Assert.AreEqual(true, y.CanExecute(""));
            y.Execute("");
            Assert.AreEqual(2, callCount);
        }

        [TestMethod]
        public void DelegateCommand_CtrTest1()
        {
            try
            {
                var x = new DelegateCommand<string>((Action<string>)null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("command", ex.ParamName);
            }
        }

        [TestMethod]
        public void DelegateCommand_CtrTest2()
        {
            try
            {
                var x = new DelegateCommand<string>((Action<object>)null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("command", ex.ParamName);
            }
        }

        [TestMethod]
        public void DelegateCommand_EventTest1()
        {
            var eventFired = false;
            EventHandler foo = (s, e) => eventFired = true;

            var cmd = new DelegateCommand<string>(x => { }, x => true);
            cmd.CanExecuteChanged += foo;
            Assert.IsFalse(eventFired);

            cmd.OnCanExecuteChanged();
            Assert.IsTrue(eventFired);

            eventFired = false;
            cmd.CanExecuteChanged -= foo;
            cmd.OnCanExecuteChanged();
            Assert.IsFalse(eventFired);
        }

        [TestMethod]
        public void DelegateCommand_EventTest2()
        {
            var eventFired = false;
            EventHandler foo = (s, e) => eventFired = true;

            var cmd = new DelegateCommand<string>(x => { }, null);
            cmd.CanExecuteChanged += foo;
            Assert.IsFalse(eventFired);

            cmd.OnCanExecuteChanged();
            Assert.IsFalse(eventFired);

            eventFired = false;
            cmd.CanExecuteChanged -= foo;
            cmd.OnCanExecuteChanged();
            Assert.IsFalse(eventFired);
        }

        [TestMethod]
        public void DelegateCommand_ParameterTypeTest1()
        {
            try
            {
                var callCount = 0;
                var x = new DelegateCommand<string>(p => callCount++, p => true);
                var y = (ICommand)x;
                y.Execute(5);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("parameter", ex.ParamName);
            }
        }

        [TestMethod]
        public void DelegateCommand_ParameterTypeTest2()
        {
            try
            {
                var callCount = 0;
                var x = new DelegateCommand<string>(p => callCount++, p => true);
                var y = (ICommand)x;
                y.CanExecute(5);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("parameter", ex.ParamName);
            }
        }
    }
}
