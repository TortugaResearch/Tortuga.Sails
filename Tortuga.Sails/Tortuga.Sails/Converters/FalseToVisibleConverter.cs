using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters
{
    /// <summary>
    /// Use this converter to show a control when the bound value is false. Null/true will hide the control.
    /// For WPF, the parameter is used to choose between Collapsed and Hidden. The default is Collapsed.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    [ValueConversion(typeof(bool), typeof(Visibility?))]
    [ValueConversion(typeof(bool?), typeof(Visibility))]
    [ValueConversion(typeof(bool?), typeof(Visibility?))]
    public class FalseToVisibleConverter : OneWayMarkupValueConverter<FalseToVisibleConverter>
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">Boolean</param>
        /// <param name="targetType">Visibility</param>
        /// <param name="parameter">Visibility to use when the bound value is true or null.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckValueType<bool>(value);
            CheckTargetType(targetType, typeof(Visibility), typeof(Visibility?));

            var newVisibility = Visibility.Collapsed;

            if (parameter is Visibility)
                newVisibility = (Visibility)parameter;
            else
            {
                var stringParameter = parameter as string;
                if (stringParameter != null && string.Compare(stringParameter.ToUpperInvariant(), "HIDDEN", StringComparison.Ordinal) == 0)
                    newVisibility = Visibility.Hidden;
            }

            if (value == null)
                return newVisibility; ;

            if ((bool)value == true)
                return newVisibility;

            return Visibility.Visible;
        }
    }
}
