using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class FalseToVisibleConverterTests : ConverterTest<FalseToVisibleConverter>
    {
        [TestMethod]
        public void FalseToVisibleConverter_Test()
        {
            Convert(Visibility.Collapsed, null);
            Convert(Visibility.Collapsed, null, Visibility.Collapsed);
            Convert(Visibility.Hidden, null, Visibility.Hidden);
            Convert(Visibility.Collapsed, null, "Collapsed");
            Convert(Visibility.Hidden, null, "Hidden");

            Convert(Visibility.Visible, false);
            Convert(Visibility.Visible, false, Visibility.Collapsed);
            Convert(Visibility.Visible, false, Visibility.Hidden);
            Convert(Visibility.Visible, false, "Collapsed");
            Convert(Visibility.Visible, false, "Hidden");

            Convert(Visibility.Collapsed, true);
            Convert(Visibility.Collapsed, true, Visibility.Collapsed);
            Convert(Visibility.Hidden, true, Visibility.Hidden);
            Convert(Visibility.Collapsed, true, "Collapsed");
            Convert(Visibility.Hidden, true, "Hidden");

            BadValue(0);
            BadValue("");

            BadTargetType<int>();
            BadTargetType<string>();

            NoConvertBack();
        }
    }
}