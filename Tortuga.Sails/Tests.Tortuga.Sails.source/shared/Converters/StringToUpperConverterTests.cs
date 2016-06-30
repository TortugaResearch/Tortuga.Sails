using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class StringToUpperConverterTests : ConverterTest<StringToUpperConverter>
    {
        [TestMethod]
        public void StringToUpperConverter_Test()
        {
            Normalize<string>(null, null);
            Normalize("", "");
            Normalize("ABC", "Abc");
            Normalize("ABC", "Abc", culture: System.Globalization.CultureInfo.InstalledUICulture);

            BadValue(0);
            BadTargetType<int>();

        }
    }
}
