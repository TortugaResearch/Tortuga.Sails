using System;
using System.Globalization;
using System.Windows.Data;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters
{
    /// <summary>
    /// Inverts a boolean or nullable boolean. This is a two-way converter.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    [ValueConversion(typeof(bool?), typeof(bool?))]
    public sealed class NotConverter : MarkupValueConverter<NotConverter>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value">Boolean</param>
        /// <param name="targetType">Boolean</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckValueType<bool>(value);
            CheckTargetType(targetType, typeof(bool), typeof(bool?));

            //nullable bool support
            if (value == null)
                return null;

            //normal bool support
            var temp = (bool)value;
            return !temp;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
