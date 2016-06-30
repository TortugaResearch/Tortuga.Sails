using System;
using System.Globalization;

namespace Tortuga.Sails.Converters.Internals
{


    /// <summary>
    /// Base class for one-way value converters
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OneWayMarkupValueConverter<T> : MarkupValueConverter<T> where T : MarkupValueConverter<T>, new()
    {
        /// <summary>
        /// This method always throws a NotImplementedException
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public sealed override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
