using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Tortuga.Sails.Tests.Converters
{
    public abstract class ConverterTest<TConverter> where TConverter : IValueConverter, new()
    {
        protected void BadParameter(object source, object parameter, CultureInfo culture = null)
        {
            var converter = new TConverter();
            try
            {
                converter.Convert(source, typeof(object), parameter, culture);
                Assert.Fail("Expected an ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("parameter", ex.ParamName);
            }
        }

        protected void BadTargetType<TTargetType>()
        {
            var converter = new TConverter();
            try
            {
                converter.Convert(null, typeof(TTargetType), null, null);
                Assert.Fail("Expected an ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("targetType", ex.ParamName);
            }
        }

        protected void BadValue(object source, object parameter = null, CultureInfo culture = null)
        {
            var converter = new TConverter();
            try
            {
                converter.Convert(source, typeof(object), parameter, culture);
                Assert.Fail("Expected an ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("value", ex.ParamName);
            }
        }

        protected void Convert<TTargetType>(TTargetType expected, object source, object parameter = null, CultureInfo culture = null)
        {
            var converter = new TConverter();
            var result = converter.Convert(source, typeof(TTargetType), parameter, culture);
            Assert.AreEqual(expected, result);
        }

        protected void ConvertBack<TTargetType>(TTargetType expected, object source, object parameter = null, CultureInfo culture = null)
        {
            var converter = new TConverter();
            var result = converter.ConvertBack(source, typeof(TTargetType), parameter, culture);
            Assert.AreEqual(expected, result);
        }

        protected void NoConvertBack()
        {
            var converter = new TConverter();
            try
            {
                converter.ConvertBack(null, null, null, null);
                Assert.Fail("Expected a NotImplementedException");
            }
            catch (NotImplementedException)
            {
            }
        }

        /// <summary>
        /// This ensures that converting and converting-back have the same result. For example FooBar --> foobar --> foobar.
        /// </summary>
        /// <typeparam name="TTargetType"></typeparam>
        /// <param name="expected"></param>
        /// <param name="source"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        protected void Normalize<TTargetType>(TTargetType expected, object source, object parameter = null, CultureInfo culture = null)
        {
            var converter = new TConverter();

            var result = converter.Convert(source, typeof(TTargetType), parameter, culture);
            var typedResult = (TTargetType)result;
            Assert.AreEqual(expected, result);

            var sourceBackresult = converter.ConvertBack(source, typeof(TTargetType), parameter, culture);
            Assert.AreEqual(expected, sourceBackresult);

            var sourceType = source == null ? typeof(object) : source.GetType();
            var backResult = converter.ConvertBack(typedResult, sourceType, parameter, culture);
            Assert.AreEqual(result, backResult);
        }

        protected void RoundTrip<TTargetType>(TTargetType expected, object source, object parameter = null, CultureInfo culture = null)
        {
            var converter = new TConverter();
            var result = converter.Convert(source, typeof(TTargetType), parameter, culture);
            var typedResult = (TTargetType)result;
            Assert.AreEqual(expected, result);

            var sourceType = source == null ? typeof(object) : source.GetType();
            var backResult = converter.ConvertBack(typedResult, sourceType, parameter, culture);
            Assert.AreEqual(source, backResult);
        }
    }
}
