using System;
using System.Collections;
using System.Globalization;
using System.Numerics;
using System.Windows;
using System.Windows.Data;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters
{
    /// <summary>
    /// Converts null to Collapsed.
    /// Converts 0 to Collapsed, other numbers to Visible.
    /// Throws on non-numeric types
    /// For WPF, the parameter is used to choose between Collapsed and Hidden. The default is Collapsed.
    /// </summary>
    [ValueConversion(typeof(BigInteger), typeof(Visibility))]
    [ValueConversion(typeof(BigInteger), typeof(Visibility?))]
    [ValueConversion(typeof(BigInteger?), typeof(Visibility))]
    [ValueConversion(typeof(BigInteger?), typeof(Visibility?))]
    [ValueConversion(typeof(byte), typeof(Visibility))]
    [ValueConversion(typeof(byte), typeof(Visibility?))]
    [ValueConversion(typeof(byte?), typeof(Visibility))]
    [ValueConversion(typeof(byte?), typeof(Visibility?))]
    [ValueConversion(typeof(decimal), typeof(Visibility))]
    [ValueConversion(typeof(decimal), typeof(Visibility?))]
    [ValueConversion(typeof(decimal?), typeof(Visibility))]
    [ValueConversion(typeof(decimal?), typeof(Visibility?))]
    [ValueConversion(typeof(double), typeof(Visibility))]
    [ValueConversion(typeof(double), typeof(Visibility?))]
    [ValueConversion(typeof(double?), typeof(Visibility))]
    [ValueConversion(typeof(float), typeof(Visibility))]
    [ValueConversion(typeof(float), typeof(Visibility?))]
    [ValueConversion(typeof(float?), typeof(Visibility))]
    [ValueConversion(typeof(float?), typeof(Visibility?))]
    [ValueConversion(typeof(ICollection), typeof(Visibility))]
    [ValueConversion(typeof(ICollection), typeof(Visibility?))]
    [ValueConversion(typeof(IEnumerable), typeof(Visibility))]
    [ValueConversion(typeof(IEnumerable), typeof(Visibility?))]
    [ValueConversion(typeof(int), typeof(Visibility))]
    [ValueConversion(typeof(int), typeof(Visibility?))]
    [ValueConversion(typeof(int?), typeof(Visibility))]
    [ValueConversion(typeof(int?), typeof(Visibility?))]
    [ValueConversion(typeof(long), typeof(Visibility))]
    [ValueConversion(typeof(long), typeof(Visibility?))]
    [ValueConversion(typeof(long?), typeof(Visibility))]
    [ValueConversion(typeof(long?), typeof(Visibility?))]
    [ValueConversion(typeof(sbyte), typeof(Visibility))]
    [ValueConversion(typeof(sbyte), typeof(Visibility?))]
    [ValueConversion(typeof(sbyte?), typeof(Visibility))]
    [ValueConversion(typeof(sbyte?), typeof(Visibility?))]
    [ValueConversion(typeof(short), typeof(Visibility))]
    [ValueConversion(typeof(short), typeof(Visibility?))]
    [ValueConversion(typeof(short?), typeof(Visibility))]
    [ValueConversion(typeof(short?), typeof(Visibility?))]
    [ValueConversion(typeof(string), typeof(Visibility))]
    [ValueConversion(typeof(string), typeof(Visibility?))]
    [ValueConversion(typeof(uint), typeof(Visibility))]
    [ValueConversion(typeof(uint), typeof(Visibility?))]
    [ValueConversion(typeof(uint?), typeof(Visibility))]
    [ValueConversion(typeof(uint?), typeof(Visibility?))]
    [ValueConversion(typeof(ulong), typeof(Visibility))]
    [ValueConversion(typeof(ulong), typeof(Visibility?))]
    [ValueConversion(typeof(ulong?), typeof(Visibility))]
    [ValueConversion(typeof(ulong?), typeof(Visibility?))]
    [ValueConversion(typeof(ushort), typeof(Visibility))]
    [ValueConversion(typeof(ushort), typeof(Visibility?))]
    [ValueConversion(typeof(ushort?), typeof(Visibility))]
    [ValueConversion(typeof(ushort?), typeof(Visibility?))]
    public partial class NotZeroToVisibleConverter : OneWayMarkupValueConverter<NotZeroToVisibleConverter>
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">Visibility</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <exception cref="System.ArgumentException">value is not a number - value</exception>

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckParameterType(parameter, typeof(Visibility), typeof(string));

            var newVisibility = Visibility.Collapsed;

            if (parameter is Visibility)
                newVisibility = (Visibility)parameter;
            else
            {
                var stringParameter = parameter as string;
                if (stringParameter != null && string.Equals(stringParameter, "HIDDEN", StringComparison.InvariantCultureIgnoreCase))
                    newVisibility = Visibility.Hidden;
            }

            bool returnValue;

            if (value == null)
                returnValue = false;
            //Common types
            else if (value is int)
                returnValue = (int)value != 0;
            else if (value is decimal)
                returnValue = (decimal)value != 0;
            else if (value is float)
                returnValue = (float)value != 0;
            else if (value is double)
                returnValue = (double)value != 0;
            else if (value is string)
                returnValue = ((string)value).Length != 0;
            else if (value is ICollection)
                returnValue = ((ICollection)value).Count != 0;
            else if (value is IEnumerable)
            {
                var enumerator = ((IEnumerable)value).GetEnumerator();

                if (enumerator.MoveNext()) //count >= 1
                    returnValue = true;
                else
                    returnValue = false;
            }

            //other numeric types
            else if (value is byte)
                returnValue = (byte)value != 0;
            else if (value is sbyte)
                returnValue = (sbyte)value != 0;
            else if (value is short)
                returnValue = (short)value != 0;
            else if (value is ushort)
                returnValue = (ushort)value != 0;
            else if (value is uint)
                returnValue = (uint)value != 0;
            else if (value is long)
                returnValue = (long)value != 0;
            else if (value is ulong)
                returnValue = (ulong)value != 0;
            else if (value is BigInteger)
                returnValue = (BigInteger)value != 0;
            else
                throw new ArgumentException($"{nameof(value)} is not a number", nameof(value));

            if (returnValue)
                return Visibility.Visible;
            else
                return newVisibility;
        }
    }
}
