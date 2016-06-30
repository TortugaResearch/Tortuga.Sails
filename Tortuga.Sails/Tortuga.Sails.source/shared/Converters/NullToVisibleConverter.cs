using System;
using System.Globalization;
using System.Windows;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters
{
    /// <summary>
    /// Use this converter to show a control when the bound value is null or an empty string.
    /// For WPF, the parameter is used to choose between Collapsed and Hidden. The default is Collapsed.
    /// </summary>
	public class NullToVisibleConverter : OneWayMarkupValueConverter<NullToVisibleConverter>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Any nullable type</param>
        /// <param name="targetType">Visibility</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var newVisibility = Visibility.Collapsed;

            if (parameter is Visibility)
                newVisibility = (Visibility)parameter;
            else
            {
                var stringParameter = parameter as string;
                if (stringParameter != null && stringParameter.ToUpperInvariant() == "HIDDEN")
                    newVisibility = Visibility.Hidden;
            }

            if (value == null)
                return Visibility.Visible;

            if (value is string && string.IsNullOrWhiteSpace((string)value))
                return Visibility.Visible;

            return newVisibility;
        }

    }
}
