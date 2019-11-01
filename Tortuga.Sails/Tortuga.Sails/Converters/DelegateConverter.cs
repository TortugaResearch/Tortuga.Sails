using System;
using System.Globalization;
using System.Windows.Data;

namespace Tortuga.Sails.Converters
{
    /// <summary>
    /// This represents a IValueConverter conversion function.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>

    public delegate object ValueConversion(object value, Type targetType, object parameter, CultureInfo culture);

    /// <summary>
    /// Class DelegateConverter.
    /// Implements the <see cref="System.Windows.Data.IValueConverter" />
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class DelegateConverter : IValueConverter
    {
        readonly ValueConversion m_Convert;
        readonly ValueConversion m_ConvertBack;
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateConverter"/> class.
        /// </summary>
        /// <param name="convert">The convert.</param>

        public DelegateConverter(ValueConversion convert)
            : this(convert, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateConverter"/> class.
        /// </summary>
        /// <param name="convert">The convert.</param>
        /// <param name="convertBack">The convert back.</param>
        /// <exception cref="System.ArgumentNullException">convert</exception>

        public DelegateConverter(ValueConversion convert, ValueConversion? convertBack)
        {
            if (convert == null)
                throw new ArgumentNullException(nameof(convert), $"{nameof(convert)} is null.");
            m_Convert = convert;

            if (convertBack != null)
                m_ConvertBack = convertBack;
            else
                m_ConvertBack = (v, t, p, c) => { throw new NotImplementedException(); };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateConverter"/> class.
        /// </summary>
        /// <param name="convert">The convert.</param>

        public DelegateConverter(Func<object, object> convert)
            : this(convert, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateConverter"/> class.
        /// </summary>
        /// <param name="convert">The convert.</param>
        /// <param name="convertBack">The convert back.</param>
        /// <exception cref="System.ArgumentNullException">convert</exception>

        public DelegateConverter(Func<object, object> convert, Func<object, object>? convertBack)
        {
            if (convert == null)
                throw new ArgumentNullException(nameof(convert), $"{nameof(convert)} is null.");

            m_Convert = (v, t, p, c) => convert(v);

            if (convertBack != null)
                m_ConvertBack = (v, t, p, c) => convertBack(v);
            else
                m_ConvertBack = (v, t, p, c) => { throw new NotImplementedException(); };
        }

        /// <summary>
        /// Modifies the source data before passing it to the target for display in the UI.
        /// </summary>
        /// <param name="value">The source data being passed to the target.</param>
        /// <param name="targetType">The <see cref="System.Type" /> of data expected by the target dependency property.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="culture">The culture of the conversion.</param>
        /// <returns>The value to be passed to the target dependency property.</returns>

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return m_Convert(value, targetType, parameter, culture);
        }

        /// <summary>
        /// Modifies the target data before passing it to the source object.  This method is called only in <see cref="System.Windows.Data.BindingMode.TwoWay" /> bindings.
        /// </summary>
        /// <param name="value">The target data being passed to the source.</param>
        /// <param name="targetType">The <see cref="System.Type" /> of data expected by the source object.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="culture">The culture of the conversion.</param>
        /// <returns>The value to be passed to the source object.</returns>

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return m_ConvertBack(value, targetType, parameter, culture);
        }
    }
}
