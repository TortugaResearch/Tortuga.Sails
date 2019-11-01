using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tortuga.Sails.Tests.Mocks;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class MarkupValueConverterTests
    {
        [TestMethod]
        public void MarkupValueConverter_CheckParameterTypeTest1()
        {
            MockMarkupValueConverter.CheckParameterType("abc", typeof(string), typeof(int), typeof(long));
        }

        [TestMethod]
        public void MarkupValueConverter_CheckParameterTypeTest2()
        {
            try
            {
                MockMarkupValueConverter.CheckParameterType("abc", typeof(int), typeof(long));
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("parameter", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckParameterTypeTest3()
        {
            try
            {
                MockMarkupValueConverter.CheckParameterType("abc");
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("validParameterTypes", ex.ParamName);
            }
        }


        [TestMethod]
        public void MarkupValueConverter_CheckParameterTypeTest4()
        {
            try
            {
                MockMarkupValueConverter.CheckParameterType("abc", null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("validParameterTypes", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckParameterTypeTest5()
        {
            MockMarkupValueConverter.CheckParameterType(null, typeof(string), typeof(int), typeof(long));
        }

        [TestMethod]
        public void MarkupValueConverter_CheckRequiredParameterTypeTest1()
        {
            MockMarkupValueConverter.CheckRequiredParameterType("abc", typeof(string), typeof(int), typeof(long));
        }

        [TestMethod]
        public void MarkupValueConverter_CheckRequiredParameterTypeTest2()
        {
            try
            {
                MockMarkupValueConverter.CheckRequiredParameterType("abc", typeof(int), typeof(long));
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("parameter", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckRequiredParameterTypeTest3()
        {
            try
            {
                MockMarkupValueConverter.CheckRequiredParameterType("abc");
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("validParameterTypes", ex.ParamName);
            }
        }


        [TestMethod]
        public void MarkupValueConverter_CheckRequiredParameterTypeTest4()
        {
            try
            {
                MockMarkupValueConverter.CheckRequiredParameterType("abc", null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("validParameterTypes", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckRequiredParameterTypeTest5()
        {
            try
            {
                MockMarkupValueConverter.CheckRequiredParameterType(null, typeof(int), typeof(long));
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("parameter", ex.ParamName);
            }
        }


        [TestMethod]
        public void MarkupValueConverter_CheckValueTypeTest1()
        {
            MockMarkupValueConverter.CheckValueType("abc", typeof(string), typeof(int), typeof(long));
        }

        [TestMethod]
        public void MarkupValueConverter_CheckValueTypeTest2()
        {
            try
            {
                MockMarkupValueConverter.CheckValueType("abc", typeof(int), typeof(long));
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("value", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckValueTypeTest3()
        {
            try
            {
                MockMarkupValueConverter.CheckValueType("abc");
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("validValueTypes", ex.ParamName);
            }
        }


        [TestMethod]
        public void MarkupValueConverter_CheckValueTypeTest4()
        {
            try
            {
                MockMarkupValueConverter.CheckValueType("abc", null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("validValueTypes", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckValueTypeTest5()
        {
            MockMarkupValueConverter.CheckValueType(null, typeof(string));
        }

        [TestMethod]
        public void MarkupValueConverter_CheckParameterType1Test1()
        {
            MockMarkupValueConverter.CheckParameterType<string>("abc");
        }

        [TestMethod]
        public void MarkupValueConverter_CheckParameterType1Test2()
        {
            try
            {
                MockMarkupValueConverter.CheckParameterType<int>("abc");
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("parameter", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckParameterType1Test3()
        {
            MockMarkupValueConverter.CheckParameterType<string>(null);
        }


        [TestMethod]
        public void MarkupValueConverter_CheckValueType1Test1()
        {
            MockMarkupValueConverter.CheckValueType<string>("abc");
        }

        [TestMethod]
        public void MarkupValueConverter_CheckValueType1Test2()
        {
            try
            {
                MockMarkupValueConverter.CheckValueType<int>("abc");
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("value", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckValueType1Test3()
        {
            MockMarkupValueConverter.CheckValueType<string>(null);
        }


        [TestMethod]
        public void MarkupValueConverter_CheckTargetTypeTest1()
        {
            MockMarkupValueConverter.CheckTargetType(typeof(string), typeof(string), typeof(int), typeof(long));
        }

        [TestMethod]
        public void MarkupValueConverter_CheckTargetTypeTest2()
        {
            try
            {
                MockMarkupValueConverter.CheckTargetType(typeof(string), typeof(int), typeof(long));
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("targetType", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckTargetTypeTest3()
        {
            try
            {
                MockMarkupValueConverter.CheckTargetType(typeof(string));
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("validTargetTypes", ex.ParamName);
            }
        }


        [TestMethod]
        public void MarkupValueConverter_CheckTargetTypeTest4()
        {
            try
            {
                MockMarkupValueConverter.CheckTargetType(typeof(string), null);
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("validTargetTypes", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckTargetTypeTest5()
        {
            try
            {
                MockMarkupValueConverter.CheckTargetType(null, typeof(string), typeof(int), typeof(long));
                Assert.Fail("Expected an exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("targetType", ex.ParamName);
            }
        }

        [TestMethod]
        public void MarkupValueConverter_CheckTargetTypeTest6()
        {
            MockMarkupValueConverter.CheckTargetType(typeof(object), typeof(string), typeof(int), typeof(long));
        }


        [TestMethod]
        public void MarkupValueConverter_ProvideValueTest()
        {
            var converter1 = new MockMarkupValueConverter();
            var converter2 = new MockMarkupValueConverter();
            var result1 = converter1.ProvideValue(null);
            var result2 = converter2.ProvideValue(null);
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreSame(result1, result2);
        }

        [TestMethod]
        public void MarkupValueConverter_DefaultTest1()
        {
            var result = MockMarkupValueConverter.Default(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void MarkupValueConverter_DefaultTest2()
        {
            var result = MockMarkupValueConverter.Default(typeof(int));
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MarkupValueConverter_DefaultTest3()
        {
            var result = MockMarkupValueConverter.Default(typeof(String));
            Assert.IsNull(result);
        }



    }
}
