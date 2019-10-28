using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace softaware.Xaml.Converters.Tests
{
    [TestClass]
    public class MappingConverterTests
    {
        [TestMethod]
        public void TestBooleanToVisibilityConverter()
        {
            var converter = new MappingConverter();
            converter.Mappings.Add(new Mapping() { From = true, To = Visibility.Visible });
            converter.Mappings.Add(new Mapping() { From = false, To = Visibility.Collapsed });

            Assert.AreEqual(Visibility.Visible, converter.Convert(true, null, null, null));
            Assert.AreEqual(Visibility.Collapsed, converter.Convert(false, null, null, null));

            Assert.AreEqual(true, converter.ConvertBack(Visibility.Visible, null, null, null));
            Assert.AreEqual(false, converter.ConvertBack(Visibility.Collapsed, null, null, null));
        }

        [TestMethod]
        public void TestNoMappingReturnsValue()
        {
            var converter = new MappingConverter();
            converter.Mappings.Add(new Mapping() { From = null, To = 1 });

            Assert.AreEqual(1, converter.Convert(null, null, null, null));
            Assert.AreEqual(2, converter.Convert(2, null, null, null));

            Assert.AreEqual(null, converter.ConvertBack(1, null, null, null));
            Assert.AreEqual(2, converter.ConvertBack(2, null, null, null));
        }
    }
}
