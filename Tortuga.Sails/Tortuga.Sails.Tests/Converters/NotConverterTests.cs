using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class NotConverterTests : ConverterTest<NotConverter>
    {
        [TestMethod]
        public void NotConverter_Test()
        {
            RoundTrip<bool>(false, true);
            RoundTrip<bool>(true, false);

            RoundTrip<bool?>(null, null);
            RoundTrip<bool?>(false, true);
            RoundTrip<bool?>(true, false);

            BadValue(0);
            BadValue("");

            BadTargetType<int>();
            BadTargetType<string>();
        }
    }
}
