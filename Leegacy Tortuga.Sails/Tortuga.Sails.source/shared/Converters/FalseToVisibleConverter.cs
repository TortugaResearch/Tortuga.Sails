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
        /// 
        /// </summary>
        /// <param name="value">Boolean</param>
        /// <param name="targetType">Visibility</param>
        /// <param name="parameter">Visibility to use when the bound value is true or null.</param>
        /// <param name="culture"></param>
        /// <returns></returns>

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
                if (stringParameter != null && stringParameter.ToUpperInvariant() == "HIDDEN")
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
