﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters
{
    /// <summary>
    /// Use this converter to hide a control when the bound value is null or an empty string.
    /// For WPF, the parameter is used to choose between Collapsed and Hidden. The default is Collapsed.
    /// </summary>
	[ValueConversion(typeof(object), typeof(bool))]
    public class NotNullToVisibleConverter : OneWayMarkupValueConverter<NotNullToVisibleConverter>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType">Visibility</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckTargetType(targetType, typeof(Visibility), typeof(Visibility?));
            CheckParameterType(parameter, typeof(Visibility), typeof(string));

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
                return newVisibility;

            if (value is string && string.IsNullOrWhiteSpace((string)value))
                return newVisibility;


            return Visibility.Visible;
        }

    }
}
