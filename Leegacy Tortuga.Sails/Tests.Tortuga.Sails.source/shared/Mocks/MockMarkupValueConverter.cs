using System;
using System.Globalization;
using Tortuga.Sails.Converters.Internals;

namespace Tortuga.Sails.Tests.Mocks
{
    public class MockMarkupValueConverter : MarkupValueConverter<MockMarkupValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public static new object Default(Type targetType)
        {
            return MarkupValueConverter<MockMarkupValueConverter>.Default(targetType);
        }

        public static new void CheckTargetType(Type targetType, params Type[] validTargetTypes)
        {
            MarkupValueConverter<MockMarkupValueConverter>.CheckTargetType(targetType, validTargetTypes);
        }

        public static new void CheckValueType(object value, params Type[] validValueTypes)
        {
            MarkupValueConverter<MockMarkupValueConverter>.CheckValueType(value, validValueTypes);
        }

        public static new void CheckValueType<TValueType>(object value)
        {
            MarkupValueConverter<MockMarkupValueConverter>.CheckValueType<TValueType>(value);
        }

        public static new void CheckParameterType<TValueType>(object parameter)
        {
            MarkupValueConverter<MockMarkupValueConverter>.CheckParameterType<TValueType>(parameter);
        }

        public static new void CheckRequiredParameterType<TValueType>(object parameter)
        {
            MarkupValueConverter<MockMarkupValueConverter>.CheckRequiredParameterType<TValueType>(parameter);
        }


        public static new void CheckParameterType(object parameter, params Type[] validParameterTypes)
        {
            MarkupValueConverter<MockMarkupValueConverter>.CheckParameterType(parameter, validParameterTypes);
        }

        public static new void CheckRequiredParameterType(object parameter, params Type[] validParameterTypes)
        {
            MarkupValueConverter<MockMarkupValueConverter>.CheckRequiredParameterType(parameter, validParameterTypes);
        }

    }
}
