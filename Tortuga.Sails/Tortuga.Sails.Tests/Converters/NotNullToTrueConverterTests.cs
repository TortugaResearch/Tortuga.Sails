using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class NotNullToTrueConverterTests : ConverterTest<NotNullToTrueConverter>
    {
        [TestMethod]
        public void NotNullToTrueConverter_Test()
        {
            Convert<bool>(false, null);
            Convert<bool>(true, 0);
            Convert<bool>(true, "");

            Convert<bool?>(false, null);
            Convert<bool?>(true, 0);
            Convert<bool?>(true, "");

            BadTargetType<int>();
            BadTargetType<string>();

            NoConvertBack();
        }
    }
}
