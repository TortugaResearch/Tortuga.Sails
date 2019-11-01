using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class NullToTrueConverterTests : ConverterTest<NullToTrueConverter>
    {
        [TestMethod]
        public void NullToTrueConverter_Test()
        {
            Convert<bool>(true, null);
            Convert<bool>(false, 0);
            Convert<bool>(false, "");

            Convert<bool?>(true, null);
            Convert<bool?>(false, 0);
            Convert<bool?>(false, "");

            BadTargetType<int>();
            BadTargetType<string>();

            NoConvertBack();
        }
    }
}
