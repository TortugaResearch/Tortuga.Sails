using System.Globalization;
using System.Numerics;
using System.Windows.Data;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters;

/// <summary>
/// Converts empty strings into nulls.
/// Implements the <see cref="IValueConverter" />
/// </summary>
/// <seealso cref="IValueConverter" />
[ValueConversion(typeof(BigInteger), typeof(string))]
[ValueConversion(typeof(BigInteger?), typeof(string))]
[ValueConversion(typeof(byte), typeof(string))]
[ValueConversion(typeof(byte?), typeof(string))]
[ValueConversion(typeof(decimal), typeof(string))]
[ValueConversion(typeof(decimal?), typeof(string))]
[ValueConversion(typeof(double), typeof(string))]
[ValueConversion(typeof(double?), typeof(string))]
[ValueConversion(typeof(short), typeof(string))]
[ValueConversion(typeof(short?), typeof(string))]
[ValueConversion(typeof(int), typeof(string))]
[ValueConversion(typeof(int?), typeof(string))]
[ValueConversion(typeof(long), typeof(string))]
[ValueConversion(typeof(long?), typeof(string))]
[ValueConversion(typeof(sbyte), typeof(string))]
[ValueConversion(typeof(sbyte?), typeof(string))]
[ValueConversion(typeof(float), typeof(string))]
[ValueConversion(typeof(float?), typeof(string))]
[ValueConversion(typeof(string), typeof(string))]
[ValueConversion(typeof(ushort), typeof(string))]
[ValueConversion(typeof(ushort?), typeof(string))]
[ValueConversion(typeof(uint), typeof(string))]
[ValueConversion(typeof(uint?), typeof(string))]
[ValueConversion(typeof(ulong), typeof(string))]
[ValueConversion(typeof(ulong?), typeof(string))]
public class NullableValueConverter : MarkupValueConverter<NullableValueConverter>
{
    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">The value that is produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
    public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (string.IsNullOrEmpty(value?.ToString()))
            return null;

        //TODO: Shouldn't this have a big switch block to enforce the conversion?

        return value;
    }
}
