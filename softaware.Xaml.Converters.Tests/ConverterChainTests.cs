using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace softaware.Xaml.Converters.Tests
{
    [TestClass]
    public class ConverterChainTests
    {
        [TestMethod]
        public void TestInvertedVisibilityConverter()
        {
            var chain = new ConverterChain();
            chain.Converters.Add(new BooleanInverter());
            chain.Converters.Add(new BooleanToVisibilityConverter());

            Assert.AreEqual(Visibility.Collapsed, chain.Convert(true, null, null, null));
            Assert.AreEqual(Visibility.Visible, chain.Convert(false, null, null, null));

            Assert.AreEqual(true, chain.ConvertBack(Visibility.Collapsed, typeof(bool), null, null));
            Assert.AreEqual(false, chain.ConvertBack(Visibility.Visible, typeof(bool), null, null));
        }

        [TestMethod]
        public void TestInvertedContainsVisibilityConverter() 
        {
            var chain = new ConverterChain();
            chain.MultiConverter = new ContainsConverter();
            chain.Converters.Add(new BooleanInverter());
            chain.Converters.Add(new BooleanToVisibilityConverter());

            var array = new[] { 1, 2 };

            Assert.AreEqual(Visibility.Collapsed, chain.Convert(new object[] { array, 1 }, null, null, null));
            Assert.AreEqual(Visibility.Collapsed, chain.Convert(new object[] { array, 2 }, null, null, null));
            Assert.AreEqual(Visibility.Visible, chain.Convert(new object[] { array, 3 }, null, null, null));
        }

        [TestMethod]
        public void TestNotEmptyConverter()
        {
            var chain = new ConverterChain();
            chain.Converters.Add(new EmptyConverter());
            chain.Converters.Add(new BooleanInverter());

            Assert.AreEqual(false, chain.Convert(new int[0], null, null, null));
            Assert.AreEqual(true, chain.Convert(new[] { 1 }, null, null, null));
        }
    }
}
