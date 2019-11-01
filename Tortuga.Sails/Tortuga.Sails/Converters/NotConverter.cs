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
        /// Converts a value.
        /// </summary>
        /// <param name="value">Boolean</param>
        /// <param name="targetType">Boolean</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>

        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>

        public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
