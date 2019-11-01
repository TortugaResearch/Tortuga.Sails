using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace Tortuga.Sails.Converters.Internals
{
    /// <summary>
    /// Base class for value converters that are also exposed as a markup extension.
    /// </summary>
    /// <typeparam name="T">T is always the class inherits from MarkupValueConverter.</typeparam>
    /// <remarks>To save memory instances of this class are created and then replaced with a singleton</remarks>
    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public abstract class MarkupValueConverter<T> : MarkupExtension, IValueConverter where T : MarkupValueConverter<T>, new()
    {
        readonly static T s_PrimaryInstance = new T();

        /// <summary>
        /// This constructor verifies the concrete type was passed as the T parameter.
        /// </summary>
        protected MarkupValueConverter()
        {
        }

        /// <summary>
        /// Throws an exception if the indicated value isn't in the indicated type
        /// </summary>
        /// <param name="parameter">parameter being used for conversion</param>
        /// <param name="validParameterTypes"></param>
        /// <remarks>This does not look at type inheritance</remarks>

        protected static void CheckRequiredParameterType(object parameter, params Type[] validParameterTypes)
        {
            if (validParameterTypes == null)
                throw new ArgumentNullException(nameof(validParameterTypes), $"{nameof(validParameterTypes)} is null.");
            if (validParameterTypes.Length == 0)
                throw new ArgumentException($"{nameof(validParameterTypes)} is empty", nameof(validParameterTypes));


            if (parameter == null || !validParameterTypes.Contains(parameter.GetType()))
                throw new ArgumentException($"Parameter {nameof(parameter)} must be one of " + string.Join(", ", validParameterTypes.Select(t => t.Name).ToArray()), nameof(parameter));

        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">
        /// The value produced by the binding source.
        /// </param>
        /// <param name="targetType">
        /// The type of the binding target property.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param>
        /// <param name="culture">
        /// The culture to use in the converter.
        /// </param>

        public abstract object? Convert(object value, Type targetType, object parameter, CultureInfo culture);



        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">
        /// The value that is produced by the binding target.
        /// </param>
        /// <param name="targetType">
        /// The type to convert to.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param>
        /// <param name="culture">
        /// The culture to use in the converter.
        /// </param>

        public abstract object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// When implemented in a derived class, returns an object that is set as the value of the target property for this markup extension. 
        /// </summary>
        /// <returns>
        /// The object value to set on the property where the extension is applied. 
        /// </returns>
        /// <param name="serviceProvider">
        /// Object that can provide services for the markup extension.
        /// </param>
        public override sealed object ProvideValue(IServiceProvider serviceProvider)
        {
            return s_PrimaryInstance;
        }

        /// <summary>
        /// Throws an exception if the indicated value isn't in the indicated type
        /// </summary>
        /// <typeparam name="TValueType"></typeparam>
        /// <param name="parameter">parameter being used for conversion</param>
        /// <remarks></remarks>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]

        protected static void CheckParameterType<TValueType>(object parameter)
        {
            if (parameter == null)
                return; //allowed

            if (!(parameter is TValueType))
                throw new ArgumentException($"Parameter {nameof(parameter)} must be null or {typeof(TValueType).Name}", nameof(parameter));
        }

        /// <summary>
        /// Throws an exception if the indicated value isn't null or the indicated type
        /// </summary>
        /// <param name="parameter">parameter being used for conversion</param>
        /// <param name="validParameterTypes"></param>
        /// <remarks>This does not look at type inheritance</remarks>
        protected static void CheckParameterType(object parameter, params Type[] validParameterTypes)
        {
            if (validParameterTypes == null)
                throw new ArgumentNullException(nameof(validParameterTypes), $"{nameof(validParameterTypes)} is null.");
            if (validParameterTypes.Length == 0)
                throw new ArgumentException($"{nameof(validParameterTypes)} is empty", nameof(validParameterTypes));


            if (parameter == null)
                return; //allowed

            if (!validParameterTypes.Contains(parameter.GetType()))
                throw new ArgumentException($"Parameter '{nameof(parameter)}' must be null or one of {(string.Join(", ", validParameterTypes.Select(t => t.Name).ToArray()))}", nameof(parameter));
        }

        /// <summary>
        /// Throws an exception if the indicated value isn't in the indicated type
        /// </summary>
        /// <typeparam name="TValueType"></typeparam>
        /// <param name="parameter">parameter being used for conversion</param>
        /// <remarks></remarks>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]

        protected static void CheckRequiredParameterType<TValueType>(object parameter)
        {
            if (parameter == null || !(parameter is TValueType))
                throw new ArgumentException($"Parameter '{nameof(parameter)}' must be {typeof(TValueType).Name}", nameof(parameter));
        }

        /// <summary>
        /// Throws an exception if the indicated type isn't in the list of valid types.
        /// </summary>
        /// <param name="targetType">Type to check</param>
        /// <param name="validTargetTypes">List of types that are valid.</param>
        /// <remarks>This does not look at type inheritance</remarks>
        protected static void CheckTargetType(Type targetType, params Type[] validTargetTypes)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType), $"{nameof(targetType)} is null.");
            if (validTargetTypes == null)
                throw new ArgumentNullException(nameof(validTargetTypes), $"{nameof(validTargetTypes)} is null.");
            if (validTargetTypes.Length == 0)
                throw new ArgumentException($"{nameof(validTargetTypes)} is empty", nameof(validTargetTypes));

            if (targetType == typeof(object))
                return; //calling class is willing to accept any type

            if (!validTargetTypes.Contains(targetType))

                throw new ArgumentException($"Parameter '{nameof(targetType)}' must be one of {(string.Join(", ", validTargetTypes.Select(t => t.Name).ToArray()))}", nameof(targetType));
        }

        /// <summary>
        /// Throws an exception if the indicated value isn't in the list of valid types.
        /// </summary>
        /// <param name="value">value being converted</param>
        /// <param name="validValueTypes">List of types that are valid.</param>
        /// <remarks>This does not look at type inheritance</remarks>     
        protected static void CheckValueType(object value, params Type[] validValueTypes)
        {
            if (validValueTypes == null)
                throw new ArgumentNullException(nameof(validValueTypes), $"{nameof(validValueTypes)} is null.");
            if (validValueTypes.Length == 0)
                throw new ArgumentException($"{nameof(validValueTypes)} is empty", nameof(validValueTypes));

            if (value == null)
                return; //allowed

            if (!validValueTypes.Contains(value.GetType()))
                throw new ArgumentException($"Parameter '{nameof(value)}' must be null or one of {(string.Join(", ", validValueTypes.Select(t => t.Name).ToArray()))}", nameof(value));
        }

        /// <summary>
        /// Throws an exception if the indicated value isn't in the indicated type
        /// </summary>
        /// <typeparam name="TValueType"></typeparam>
        /// <param name="value">value being converted</param>
        /// <remarks>This does not look at type inheritance</remarks>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]

        protected static void CheckValueType<TValueType>(object value)
        {
            if (value == null)
                return; //allowed

            if (!(value is TValueType))
                throw new ArgumentException($"Parameter '{nameof(value)}' must be null or {typeof(TValueType).Name}", nameof(value));
        }

        /// <summary>
        /// Returns Default(targetType)
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns>Null for reference types, and empty instance for value types</returns>
        protected static object? Default(Type targetType)
        {
            if (targetType == null)
                return null;
            else if (targetType.IsValueType)
                return Activator.CreateInstance(targetType);
            else
                return null;
        }
    }

}

