using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters;

[TestClass]
public class NullToVisibleConverterTests : ConverterTest<NullToVisibleConverter>
{
    [TestMethod]
    public void NullToVisibleConverter_Test()
    {
        Convert(Visibility.Visible, null);
        Convert(Visibility.Visible, null, Visibility.Collapsed);
        Convert(Visibility.Visible, null, Visibility.Hidden);
        Convert(Visibility.Visible, null, "Collapsed");
        Convert(Visibility.Visible, null, "Hidden");

        Convert(Visibility.Collapsed, 0);
        Convert(Visibility.Collapsed, 0, Visibility.Collapsed);
        Convert(Visibility.Hidden, 0, Visibility.Hidden);
        Convert(Visibility.Collapsed, 0, "Collapsed");
        Convert(Visibility.Hidden, 0, "Hidden");

        Convert(Visibility.Collapsed, "");
        Convert(Visibility.Collapsed, "", Visibility.Collapsed);
        Convert(Visibility.Hidden, "", Visibility.Hidden);
        Convert(Visibility.Collapsed, "", "Collapsed");
        Convert(Visibility.Hidden, "", "Hidden");

        Convert(Visibility.Collapsed, "a");
        Convert(Visibility.Collapsed, "a", Visibility.Collapsed);
        Convert(Visibility.Hidden, "a", Visibility.Hidden);
        Convert(Visibility.Collapsed, "a", "Collapsed");
        Convert(Visibility.Hidden, "a", "Hidden");

        NoConvertBack();
    }
}
