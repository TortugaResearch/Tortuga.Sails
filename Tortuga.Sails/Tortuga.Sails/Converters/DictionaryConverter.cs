using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Converters
{
    /// <summary>
    /// This performs a dictionary lookup for conversion. The IDictionary is passed as the converter parameter.
    /// Convert goes from Key-->Value.
    /// ConvertBack goes from Value-->Key using the first matching value.
    /// If a key/value isn't found in the dictionary then default(targetType) is returned.
    /// If the value parameter is null then default(targetType) is returned.
    /// </summary>
    [ValueConversion(typeof(object), typeof(object))]
    public class DictionaryConverter : MarkupValueConverter<DictionaryConverter>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="targetType">Will return Default(targetType) if the value is null or not found in the dictionary</param>
        /// <param name="parameter">Dictionary to look up values</param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckRequiredParameterType<IDictionary>(parameter);

            if (value == null)
                return Default(targetType);

            var dictionary = (IDictionary)parameter;
            if (dictionary.Contains(value))
                return dictionary[value];

            return Default(targetType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="targetType">Will return Default(targetType) if the value is null or not found in the dictionary</param>
        /// <param name="parameter">Dictionary to look up values</param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckRequiredParameterType<IDictionary>(parameter);

            if (value == null)
                return Default(targetType);

            var dictionary = (IDictionary)parameter;
            var enumerator = dictionary.GetEnumerator();
            while (enumerator.MoveNext())
                if (enumerator.Value.Equals(value))
                    return enumerator.Key;

            return Default(targetType);
        }
    }
}
