using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters
{
    /// <summary>
    /// Converts a string to lowercase. This supports the culture parameter.
    /// If used for two-way binding then the value is lowercased in both directions.
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public sealed class StringToLowerConverter : NormalizingMarkupValueConverter<StringToLowerConverter>
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">String</param>
        /// <param name="targetType">String</param>
        /// <param name="parameter">Culture to use for conversion. Optional.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1304:SpecifyCultureInfo", MessageId = "System.String.ToLower")]
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckValueType<string>(value);
            CheckTargetType(targetType, typeof(string));

            var stringValue = (string)value;

            if (stringValue == null)
                return null;

            if (culture == null)
                return stringValue.ToLower();
            else
                return stringValue.ToLower(culture);
        }
    }
}
