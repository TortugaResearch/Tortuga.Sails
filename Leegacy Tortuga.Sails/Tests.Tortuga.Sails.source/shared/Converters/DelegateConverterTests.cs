using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class DelegateConverterTests
    {
        [TestMethod]
        public void DelegateConverter_CtrNullTest()
        {
            try
            {
                var x = new DelegateConverter((Func<object, object>)null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("convert", ex.ParamName);
            }
        }

        [TestMethod]
        public void DelegateConverter_Ctr2NullTest()
        {
            try
            {
                var x = new DelegateConverter((ValueConversion)null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("convert", ex.ParamName);
            }
        }

        [TestMethod]
        public void DelegateConverter_Ctr1Test()
        {

            ValueConversion convert = (v, t, p, c) => v.ToString();
            var converter = new DelegateConverter(convert);
            var result = converter.Convert(5, null, null, null);
            Assert.AreEqual("5", result);
            try
            {
                converter.ConvertBack(5, null, null, null);
                Assert.Fail("Expected an exception");
            }
            catch (NotImplementedException)
            {

            }

        }

        [TestMethod]
        public void DelegateConverter_Ctr2Test()
        {

            ValueConversion convert = (v, t, p, c) => v.ToString();
            ValueConversion convertBack = (v, t, p, c) => int.Parse(v.ToString());

            var converter = new DelegateConverter(convert, convertBack);
            var result = converter.Convert(5, null, null, null);
            Assert.AreEqual("5", result);

            var result2 = converter.ConvertBack("5", null, null, null);
            Assert.AreEqual(5, result2);
        }

        [TestMethod]
        public void DelegateConverter_Ctr3Test()
        {

            Func<object, object> convert = (v) => v.ToString();
            var converter = new DelegateConverter(convert);
            var result = converter.Convert(5, null, null, null);
            Assert.AreEqual("5", result);
            try
            {
                converter.ConvertBack(5, null, null, null);
                Assert.Fail("Expected an exception");
            }
            catch (NotImplementedException)
            {

            }

        }

        [TestMethod]
        public void DelegateConverter_Ctr4Test()
        {

            Func<object, object> convert = (v) => v.ToString();
            Func<object, object> convertBack = (v) => int.Parse(v.ToString());

            var converter = new DelegateConverter(convert, convertBack);
            var result = converter.Convert(5, null, null, null);
            Assert.AreEqual("5", result);

            var result2 = converter.ConvertBack("5", null, null, null);
            Assert.AreEqual(5, result2);
        }
    }

}