using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{

    [TestClass]
    public class TrueToVisibleConverterTests : ConverterTest<TrueToVisibleConverter>
    {

        [TestMethod]
        public void TrueToVisibleConverter_Test()
        {
            Convert(Visibility.Collapsed, null);
            Convert(Visibility.Collapsed, null, Visibility.Collapsed);
            Convert(Visibility.Hidden, null, Visibility.Hidden);
            Convert(Visibility.Collapsed, null, "Collapsed");
            Convert(Visibility.Hidden, null, "Hidden");

            Convert(Visibility.Collapsed, false);
            Convert(Visibility.Collapsed, false, Visibility.Collapsed);
            Convert(Visibility.Hidden, false, Visibility.Hidden);
            Convert(Visibility.Collapsed, false, "Collapsed");
            Convert(Visibility.Hidden, false, "Hidden");

            Convert(Visibility.Visible, true);
            Convert(Visibility.Visible, true, Visibility.Collapsed);
            Convert(Visibility.Visible, true, Visibility.Hidden);
            Convert(Visibility.Visible, true, "Collapsed");
            Convert(Visibility.Visible, true, "Hidden");

            BadValue(0);
            BadValue("");

            BadTargetType<int>();
            BadTargetType<string>();

            NoConvertBack();
        }
    }
}

