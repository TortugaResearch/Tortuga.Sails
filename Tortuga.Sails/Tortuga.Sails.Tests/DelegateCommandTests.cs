using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;

namespace Tortuga.Sails.Tests.Commands
{
    [TestClass]
    public class DelegateCommandTests
    {
        [TestMethod]
        public void DelegateCommand_CanExecute()
        {
            var callCount = 0;
            var x = new DelegateCommand(() => callCount++, () => true);

            Assert.AreEqual(true, x.CanExecute());
            x.Execute();
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
            var x = new DelegateCommand(() => callCount++);

            Assert.AreEqual(true, x.CanExecute());
            x.Execute();
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
                var x = new DelegateCommand((Action)null);
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

            var cmd = new DelegateCommand(() => { }, () => true);
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

            var cmd = new DelegateCommand(() => { }, null);
            cmd.CanExecuteChanged += foo;
            Assert.IsFalse(eventFired);

            cmd.OnCanExecuteChanged();
            Assert.IsFalse(eventFired);

            eventFired = false;
            cmd.CanExecuteChanged -= foo;
            cmd.OnCanExecuteChanged();
            Assert.IsFalse(eventFired);
        }
    }
}
