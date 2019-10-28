using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace softaware.Xaml.Converters.Tests
{
    [TestClass]
    public class BooleanToVisibilityConverterTests
    {
        [TestMethod]
        public void TestBooleanToVisibilityConverter()
        {
            var converter = new BooleanToVisibilityConverter();

            Assert.AreEqual(Visibility.Visible, converter.Convert(true, null, null, null));
            Assert.AreEqual(Visibility.Collapsed, converter.Convert(false, null, null, null));

            Assert.AreEqual(true, converter.ConvertBack(Visibility.Visible, null, null, null));
            Assert.AreEqual(false, converter.ConvertBack(Visibility.Collapsed, null, null, null));
        }
    }
}
