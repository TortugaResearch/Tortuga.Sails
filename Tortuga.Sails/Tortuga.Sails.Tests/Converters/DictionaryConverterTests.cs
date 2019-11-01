using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class DictionaryConverterTests : ConverterTest<DictionaryConverter>
    {
        [TestMethod]
        public void DictionaryConverter_Test()
        {
            var parameter = new Lights();
            RoundTrip("Off", 0, parameter);
            RoundTrip("On", 1, parameter);
            Convert<string>(null, 3, parameter);
            ConvertBack<int>(0, "Abc", parameter);

            RoundTrip<string>(null, null, parameter);

            Convert<string>(null, "X", parameter);

            BadParameter(1, null);
            BadParameter(1, "x");
        }
    }

    public class Lights : Dictionary<int, string>
    {
        public Lights()
        {
            Add(0, "Off");
            Add(1, "On");
        }
    }
}
