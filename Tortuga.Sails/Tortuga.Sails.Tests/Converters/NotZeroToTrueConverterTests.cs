using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class NotZeroToTrueConverterTests : ConverterTest<NotZeroToTrueConverter>
    {
        [TestMethod]
        public void NotZeroToTrueConverter_Test()
        {
            var emptyList = new List<int>();
            var emptyCollection = emptyList.OrderBy(x => x);
            var emptyString = "";

            var fullList = new List<int>() { 1, 2, 3 };
            var fullCollection = fullList.OrderBy(x => x);
            var fullString = "123";

            Convert(false, null);

            Convert(false, (Byte)0);
            Convert(false, (SByte)0);
            Convert(false, (Int16)0);
            Convert(false, (UInt16)0);
            Convert(false, (Int32)0);
            Convert(false, (UInt32)0);
            Convert(false, (Int64)0);
            Convert(false, (UInt64)0);
            Convert(false, (Single)0);
            Convert(false, (Double)0);
            Convert(false, (Decimal)0);
            Convert(false, (BigInteger)0);

            Convert(true, (Byte)1);
            Convert(true, (SByte)1);
            Convert(true, (Int16)1);
            Convert(true, (UInt16)1);
            Convert(true, (Int32)1);
            Convert(true, (UInt32)1);
            Convert(true, (Int64)1);
            Convert(true, (UInt64)1);
            Convert(true, (Single)1);
            Convert(true, (Double)1);
            Convert(true, (Decimal)1);
            Convert(true, (BigInteger)1);

            Convert(false, emptyList);
            Convert(false, emptyCollection);
            Convert(false, emptyString);

            Convert(true, fullList);
            Convert(true, fullCollection);
            Convert(true, fullString);

            BadValue(new DateTime());
            BadTargetType<string>();

            NoConvertBack();
        }
    }
}
