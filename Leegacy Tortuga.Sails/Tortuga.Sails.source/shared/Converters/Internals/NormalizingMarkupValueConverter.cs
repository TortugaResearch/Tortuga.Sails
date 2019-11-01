using System;
using System.Globalization;

namespace Tortuga.Sails.Converters.Internals
{
    /// <summary>
    /// Base class for normalizing value converters for which Convert and BackConvert return the same value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class NormalizingMarkupValueConverter<T> : MarkupValueConverter<T> where T : MarkupValueConverter<T>, new()
    {
        /// <summary>
        /// See the documentation for the Convert method on the subclass
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public sealed override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
