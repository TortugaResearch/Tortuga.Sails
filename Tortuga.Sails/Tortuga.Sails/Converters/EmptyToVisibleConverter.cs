using System.Globalization;
using System.Windows;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters;

/// <summary>
/// Use this converter to show a control when the bound value is null or an empty string.
/// For WPF, the parameter is used to choose between Collapsed and Hidden. The default is Collapsed.
/// </summary>
public class EmptyToVisibleConverter : OneWayMarkupValueConverter<EmptyToVisibleConverter>
{
    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">Any nullable type</param>
    /// <param name="targetType">Visibility</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>

    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var newVisibility = Visibility.Collapsed;

        if (parameter is Visibility)
            newVisibility = (Visibility)parameter;
        else
        {
            var stringParameter = parameter as string;
            if (stringParameter != null && string.Equals(stringParameter, "HIDDEN", StringComparison.InvariantCultureIgnoreCase))
                newVisibility = Visibility.Hidden;
        }

        if (value == null)
            return Visibility.Visible;

        if (value is string && string.IsNullOrWhiteSpace((string)value))
            return Visibility.Visible;

        return newVisibility;
    }
}
