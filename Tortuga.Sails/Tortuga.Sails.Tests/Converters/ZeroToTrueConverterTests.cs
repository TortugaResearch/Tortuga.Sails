using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class ZeroToTrueConverterTests : ConverterTest<ZeroToTrueConverter>
    {
        /// <summary>
        /// Zeroes to true converter_ test.
        /// </summary>
        [TestMethod]
        public void ZeroToTrueConverter_Test()
        {
            var emptyList = new List<int>();
            var emptyCollection = emptyList.OrderBy(x => x);
            var emptyString = "";

            var fullList = new List<int>() { 1, 2, 3 };
            var fullCollection = fullList.OrderBy(x => x);
            var fullString = "123";

            Convert(false, null);

            Convert(true, (Byte)0);
            Convert(true, (SByte)0);
            Convert(true, (Int16)0);
            Convert(true, (UInt16)0);
            Convert(true, (Int32)0);
            Convert(true, (UInt32)0);
            Convert(true, (Int64)0);
            Convert(true, (UInt64)0);
            Convert(true, (Single)0);
            Convert(true, (Double)0);
            Convert(true, (Decimal)0);
            Convert(true, (BigInteger)0);

            Convert(false, (Byte)1);
            Convert(false, (SByte)1);
            Convert(false, (Int16)1);
            Convert(false, (UInt16)1);
            Convert(false, (Int32)1);
            Convert(false, (UInt32)1);
            Convert(false, (Int64)1);
            Convert(false, (UInt64)1);
            Convert(false, (Single)1);
            Convert(false, (Double)1);
            Convert(false, (Decimal)1);
            Convert(false, (BigInteger)1);

            Convert(true, emptyList);
            Convert(true, emptyCollection);
            Convert(true, emptyString);

            Convert(false, fullList);
            Convert(false, fullCollection);
            Convert(false, fullString);

            BadValue(new DateTime());
            BadTargetType<string>();

            NoConvertBack();
        }
    }
}
