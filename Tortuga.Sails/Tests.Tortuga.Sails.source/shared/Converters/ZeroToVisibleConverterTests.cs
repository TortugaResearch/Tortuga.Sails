using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{

    [TestClass]
    public class ZeroToVisibleConverterTests : ConverterTest<ZeroToVisibleConverter>
    {

        [TestMethod]
        public void ZeroToVisibleConverter_Test()
        {
            var emptyList = new List<int>();
            var emptyCollection = emptyList.OrderBy(x => x);
            var emptyString = "";

            var fullList = new List<int>() { 1, 2, 3 };
            var fullCollection = fullList.OrderBy(x => x);
            var fullString = "123";

            Convert(Visibility.Collapsed, null);

            Convert(Visibility.Visible, (Byte)0);
            Convert(Visibility.Visible, (SByte)0);
            Convert(Visibility.Visible, (Int16)0);
            Convert(Visibility.Visible, (UInt16)0);
            Convert(Visibility.Visible, (Int32)0);
            Convert(Visibility.Visible, (UInt32)0);
            Convert(Visibility.Visible, (Int64)0);
            Convert(Visibility.Visible, (UInt64)0);
            Convert(Visibility.Visible, (Single)0);
            Convert(Visibility.Visible, (Double)0);
            Convert(Visibility.Visible, (Decimal)0);
            Convert(Visibility.Visible, (BigInteger)0);

            Convert(Visibility.Collapsed, (Byte)1);
            Convert(Visibility.Collapsed, (SByte)1);
            Convert(Visibility.Collapsed, (Int16)1);
            Convert(Visibility.Collapsed, (UInt16)1);
            Convert(Visibility.Collapsed, (Int32)1);
            Convert(Visibility.Collapsed, (UInt32)1);
            Convert(Visibility.Collapsed, (Int64)1);
            Convert(Visibility.Collapsed, (UInt64)1);
            Convert(Visibility.Collapsed, (Single)1);
            Convert(Visibility.Collapsed, (Double)1);
            Convert(Visibility.Collapsed, (Decimal)1);
            Convert(Visibility.Collapsed, (BigInteger)1);

            Convert(Visibility.Visible, (Byte)0, Visibility.Hidden);
            Convert(Visibility.Visible, (SByte)0, Visibility.Hidden);
            Convert(Visibility.Visible, (Int16)0, Visibility.Hidden);
            Convert(Visibility.Visible, (UInt16)0, Visibility.Hidden);
            Convert(Visibility.Visible, (Int32)0, Visibility.Hidden);
            Convert(Visibility.Visible, (UInt32)0, Visibility.Hidden);
            Convert(Visibility.Visible, (Int64)0, Visibility.Hidden);
            Convert(Visibility.Visible, (UInt64)0, Visibility.Hidden);
            Convert(Visibility.Visible, (Single)0, Visibility.Hidden);
            Convert(Visibility.Visible, (Double)0, Visibility.Hidden);
            Convert(Visibility.Visible, (Decimal)0, Visibility.Hidden);
            Convert(Visibility.Visible, (BigInteger)0, Visibility.Hidden);

            Convert(Visibility.Hidden, (Byte)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (SByte)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (Int16)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (UInt16)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (Int32)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (UInt32)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (Int64)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (UInt64)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (Single)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (Double)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (Decimal)1, Visibility.Hidden);
            Convert(Visibility.Hidden, (BigInteger)1, Visibility.Hidden);

            Convert(Visibility.Visible, (Byte)0, "Hidden");
            Convert(Visibility.Visible, (SByte)0, "Hidden");
            Convert(Visibility.Visible, (Int16)0, "Hidden");
            Convert(Visibility.Visible, (UInt16)0, "Hidden");
            Convert(Visibility.Visible, (Int32)0, "Hidden");
            Convert(Visibility.Visible, (UInt32)0, "Hidden");
            Convert(Visibility.Visible, (Int64)0, "Hidden");
            Convert(Visibility.Visible, (UInt64)0, "Hidden");
            Convert(Visibility.Visible, (Single)0, "Hidden");
            Convert(Visibility.Visible, (Double)0, "Hidden");
            Convert(Visibility.Visible, (Decimal)0, "Hidden");
            Convert(Visibility.Visible, (BigInteger)0, "Hidden");

            Convert(Visibility.Hidden, (Byte)1, "Hidden");
            Convert(Visibility.Hidden, (SByte)1, "Hidden");
            Convert(Visibility.Hidden, (Int16)1, "Hidden");
            Convert(Visibility.Hidden, (UInt16)1, "Hidden");
            Convert(Visibility.Hidden, (Int32)1, "Hidden");
            Convert(Visibility.Hidden, (UInt32)1, "Hidden");
            Convert(Visibility.Hidden, (Int64)1, "Hidden");
            Convert(Visibility.Hidden, (UInt64)1, "Hidden");
            Convert(Visibility.Hidden, (Single)1, "Hidden");
            Convert(Visibility.Hidden, (Double)1, "Hidden");
            Convert(Visibility.Hidden, (Decimal)1, "Hidden");
            Convert(Visibility.Hidden, (BigInteger)1, "Hidden");


            Convert(Visibility.Visible, emptyList);
            Convert(Visibility.Visible, emptyCollection);
            Convert(Visibility.Visible, emptyString);

            Convert(Visibility.Collapsed, fullList);
            Convert(Visibility.Collapsed, fullCollection);
            Convert(Visibility.Collapsed, fullString);


            BadValue(new DateTime());

            BadTargetType<string>();

            NoConvertBack();
        }
    }
}
