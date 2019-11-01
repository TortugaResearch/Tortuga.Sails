using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters
{
    [TestClass]
    public class NotNullToVisibleConverterTests : ConverterTest<NotNullToVisibleConverter>
    {
        [TestMethod]
        public void NotNullToVisibleConverter_Test()
        {
            Convert(Visibility.Collapsed, null);
            Convert(Visibility.Collapsed, null, Visibility.Collapsed);
            Convert(Visibility.Hidden, null, Visibility.Hidden);
            Convert(Visibility.Collapsed, null, "Collapsed");
            Convert(Visibility.Hidden, null, "Hidden");

            Convert(Visibility.Visible, 0);
            Convert(Visibility.Visible, 0, Visibility.Collapsed);
            Convert(Visibility.Visible, 0, Visibility.Hidden);
            Convert(Visibility.Visible, 0, "Collapsed");
            Convert(Visibility.Visible, 0, "Hidden");

            Convert(Visibility.Collapsed, "");
            Convert(Visibility.Collapsed, "", Visibility.Collapsed);
            Convert(Visibility.Hidden, "", Visibility.Hidden);
            Convert(Visibility.Collapsed, "", "Collapsed");
            Convert(Visibility.Hidden, "", "Hidden");

            Convert(Visibility.Visible, "a");
            Convert(Visibility.Visible, "a", Visibility.Collapsed);
            Convert(Visibility.Visible, "a", Visibility.Hidden);
            Convert(Visibility.Visible, "a", "Collapsed");
            Convert(Visibility.Visible, "a", "Hidden");

            BadTargetType<int>();
            BadTargetType<string>();

            NoConvertBack();
        }
    }
}
