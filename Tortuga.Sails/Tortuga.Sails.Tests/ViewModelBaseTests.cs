using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using Tortuga.Sails.Tests.ViewModel;

namespace Tortuga.Sails.Tests
{
    [TestClass]
    public class ViewModelBaseTests
    {
        [TestMethod]
        public void ViewModelBase_GetCommandA_Test1()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandA<int>("Test", _ => commandInvoked = true);
            Assert.IsFalse(commandInvoked);

            Assert.IsTrue(cmd.CanExecute(0));
            Assert.IsFalse(commandInvoked);

            cmd.Execute(0);
            Assert.IsTrue(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandA_Test2()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandA<int>("", _ => { });
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandA_Test3()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandA<int>(null, x => { });
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandA_Test4()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandA<int>("Test", null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("command", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandA_Test6()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            ICommand cmd = vm.InvokeGetCommandA<int>("Test", _ => commandInvoked = true);
            Assert.IsFalse(commandInvoked);

            try
            {
                cmd.Execute("X");
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException)
            {
                //OK
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandA_Test7()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandA<int>("Test", _ => commandInvoked = true);
            var commandAssert = new CommandEventAssert(cmd);

            cmd.OnCanExecuteChanged();
            commandAssert.ExpectNothing();
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandA_Test8()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd1 = vm.InvokeGetCommandA<int>("Test", _ => commandInvoked = true);
            var cmd2 = vm.InvokeGetCommandA<int>("Test", _ => commandInvoked = true);
            var cmd3 = vm.Test;

            Assert.AreSame(cmd1, cmd2);
            Assert.AreSame(cmd1, cmd3);
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandB_Test1()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandB("Test", x => commandInvoked = true);
            Assert.IsFalse(commandInvoked);

            Assert.IsTrue(cmd.CanExecute(0));
            Assert.IsFalse(commandInvoked);

            cmd.Execute(0);
            Assert.IsTrue(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandB_Test2()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandB("", x => { });
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandB_Test3()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandB(null, x => { });
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandB_Test4()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandB("Test", null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("command", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandB_Test5()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandB("Test", x => commandInvoked = true);
            Assert.IsFalse(commandInvoked);

            Assert.IsTrue(cmd.CanExecute("X"));
            //No type-case exception because this always returns true
        }

        [TestMethod]
        public void ViewModelBase_GetCommandB_Test7()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandB("Test", x => commandInvoked = true);
            var commandAssert = new CommandEventAssert(cmd);

            cmd.OnCanExecuteChanged();
            commandAssert.ExpectNothing();
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandB_Test8()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd1 = vm.InvokeGetCommandB("Test", x => commandInvoked = true);
            var cmd2 = vm.InvokeGetCommandB("Test", x => commandInvoked = true);
            var cmd3 = vm.Test;

            Assert.AreSame(cmd1, cmd2);
            Assert.AreSame(cmd1, cmd3);
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandC_Test1()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandC("Test", () => commandInvoked = true);
            Assert.IsFalse(commandInvoked);

            Assert.IsTrue(cmd.CanExecute());
            Assert.IsFalse(commandInvoked);

            cmd.Execute();
            Assert.IsTrue(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandC_Test2()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandC("", () => { });
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandC_Test3()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandC(null, () => { });
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandC_Test4()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandC("Test", null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("command", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandC_Test5()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            ICommand cmd = vm.InvokeGetCommandC("Test", () => commandInvoked = true);
            Assert.IsFalse(commandInvoked);

            Assert.IsTrue(cmd.CanExecute("X"));
            //No type-case exception because this always returns true
        }

        [TestMethod]
        public void ViewModelBase_GetCommandC_Test7()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandC("Test", () => commandInvoked = true);
            var commandAssert = new CommandEventAssert(cmd);

            cmd.OnCanExecuteChanged();
            commandAssert.ExpectNothing();
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandC_Test8()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd1 = vm.InvokeGetCommandC("Test", () => commandInvoked = true);
            var cmd2 = vm.InvokeGetCommandC("Test", () => commandInvoked = true);
            var cmd3 = vm.Test;

            Assert.AreSame(cmd1, cmd2);
            Assert.AreSame(cmd1, cmd3);
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandD_Test1()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandD<int>("Test", x => commandInvoked = true, x => false);
            Assert.IsFalse(commandInvoked);

            Assert.IsFalse(cmd.CanExecute(0));
            Assert.IsFalse(commandInvoked);

            cmd.Execute(0);
            Assert.IsTrue(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandD_Test2()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandD<int>("", x => { }, x => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandD_Test3()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandD<int>(null, x => { }, x => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandD_Test4()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandD<int>("Test", null, x => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("command", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandD_Test5()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            ICommand cmd = vm.InvokeGetCommandD<int>("Test", x => commandInvoked = true, x => false);
            Assert.IsFalse(commandInvoked);

            try
            {
                cmd.Execute("X");
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException)
            {
                //OK
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandD_Test6()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            ICommand cmd = vm.InvokeGetCommandD<int>("Test", x => commandInvoked = true, x => false);
            Assert.IsFalse(commandInvoked);

            try
            {
                cmd.Execute("X");
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException)
            {
                //OK
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandD_Test7()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandD<int>("Test", x => commandInvoked = true, x => false);
            var commandAssert = new CommandEventAssert(cmd);

            cmd.OnCanExecuteChanged();
            commandAssert.Expect();
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandD_Test8()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd1 = vm.InvokeGetCommandD<int>("Test", x => commandInvoked = true, x => false);
            var cmd2 = vm.InvokeGetCommandD<int>("Test", x => commandInvoked = true, x => false);
            var cmd3 = vm.Test;

            Assert.AreSame(cmd1, cmd2);
            Assert.AreSame(cmd1, cmd3);
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandE_Test1()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandE("Test", _ => commandInvoked = true, x => false);
            Assert.IsFalse(commandInvoked);

            Assert.IsFalse(cmd.CanExecute(0));
            Assert.IsFalse(commandInvoked);

            cmd.Execute(0);
            Assert.IsTrue(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandE_Test2()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandE("", x => { }, x => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandE_Test3()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandE(null, x => { }, x => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandE_Test4()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandE("Test", null, x => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("command", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandE_Test7()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandE("Test", x => commandInvoked = true, x => false);
            var commandAssert = new CommandEventAssert(cmd);

            cmd.OnCanExecuteChanged();
            commandAssert.Expect();
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandE_Test8()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd1 = vm.InvokeGetCommandE("Test", x => commandInvoked = true, x => false);
            var cmd2 = vm.InvokeGetCommandE("Test", x => commandInvoked = true, x => false);
            var cmd3 = vm.Test;

            Assert.AreSame(cmd1, cmd2);
            Assert.AreSame(cmd1, cmd3);
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandF_Test1()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandF("Test", () => commandInvoked = true, () => false);
            Assert.IsFalse(commandInvoked);

            Assert.IsFalse(cmd.CanExecute());
            Assert.IsFalse(commandInvoked);

            cmd.Execute();
            Assert.IsTrue(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandF_Test2()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandF("", () => { }, () => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandF_Test3()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandF(null, () => { }, () => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("propertyName", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandF_Test4()
        {
            var vm = new MockViewModel();
            try
            {
                vm.InvokeGetCommandF("Test", null, () => false);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("command", ex.ParamName);
            }
        }

        [TestMethod]
        public void ViewModelBase_GetCommandF_Test7()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd = vm.InvokeGetCommandF("Test", () => commandInvoked = true, () => false);
            var commandAssert = new CommandEventAssert(cmd);

            cmd.OnCanExecuteChanged();
            commandAssert.Expect();
            Assert.IsFalse(commandInvoked);
        }

        [TestMethod]
        public void ViewModelBase_GetCommandF_Test8()
        {
            var vm = new MockViewModel();
            var commandInvoked = false;

            var cmd1 = vm.InvokeGetCommandF("Test", () => commandInvoked = true, () => false);
            var cmd2 = vm.InvokeGetCommandF("Test", () => commandInvoked = true, () => false);
            var cmd3 = vm.Test;

            Assert.AreSame(cmd1, cmd2);
            Assert.AreSame(cmd1, cmd3);
            Assert.IsFalse(commandInvoked);
        }
    }
}
