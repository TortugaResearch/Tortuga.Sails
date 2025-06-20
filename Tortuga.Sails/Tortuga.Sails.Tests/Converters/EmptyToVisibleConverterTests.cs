using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using Tortuga.Sails.Converters;

namespace Tortuga.Sails.Tests.Converters;

[TestClass]
public class EmptyToVisibleConverterTests : ConverterTest<EmptyToVisibleConverter>
{
    [TestMethod]
    public void EmptyToVisibleConverter_Test()
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

        Convert(Visibility.Visible, "");
        Convert(Visibility.Visible, "", Visibility.Collapsed);
        Convert(Visibility.Visible, "", Visibility.Hidden);
        Convert(Visibility.Visible, "", "Collapsed");
        Convert(Visibility.Visible, "", "Hidden");

        Convert(Visibility.Collapsed, "a");
        Convert(Visibility.Collapsed, "a", Visibility.Collapsed);
        Convert(Visibility.Hidden, "a", Visibility.Hidden);
        Convert(Visibility.Collapsed, "a", "Collapsed");
        Convert(Visibility.Hidden, "a", "Hidden");

        NoConvertBack();
    }
}
