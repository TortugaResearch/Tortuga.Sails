using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class StringToLowerConverterTests : ConverterTest<StringToLowerConverter>
    {
        [TestMethod]
        public void StringToLowerConverter_Test()
        {
            Normalize<string>(null, null);
            Normalize("", "");
            Normalize("abc", "Abc");
            Normalize("abc", "Abc", culture: System.Globalization.CultureInfo.InstalledUICulture);

            BadValue(0);
            BadTargetType<int>();
        }
    }
}
