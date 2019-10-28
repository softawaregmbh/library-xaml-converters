using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace softaware.Xaml.Converters.Tests
{
    [TestClass]
    public class ContainsConverterTests
    {
        [TestMethod]
        public void TestString()
        {
            var converter = new ContainsConverter();
            Assert.AreEqual(true, converter.Convert(new object[] { "Test", 't' }, null, null, null));
            Assert.AreEqual(true, converter.Convert(new object[] { "Test", 'e' }, null, null, null));
            Assert.AreEqual(true, converter.Convert(new object[] { "Test", 's' }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { "Test", 'x' }, null, null, null));
        }

        [TestMethod]
        public void TestArrayList()
        {
            var converter = new ContainsConverter();
            var o = new object();
            var list = new ArrayList() { 1, "Test", o };
            Assert.AreEqual(true, converter.Convert(new object[] { list, 1 }, null, null, null));
            Assert.AreEqual(true, converter.Convert(new object[] { list, "Test" }, null, null, null));
            Assert.AreEqual(true, converter.Convert(new object[] { list, o }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { list, 2 }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { list, "x" }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { list, new object() }, null, null, null));
        }

        [TestMethod]
        public void TestGenericList()
        {
            var converter = new ContainsConverter();
            var list = new List<int>() { 1, 2, 3 };
            Assert.AreEqual(true, converter.Convert(new object[] { list, 1 }, null, null, null));
            Assert.AreEqual(true, converter.Convert(new object[] { list, 2 }, null, null, null));
            Assert.AreEqual(true, converter.Convert(new object[] { list, 3 }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { list, 0 }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { list, "x" }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { list, new object() }, null, null, null));
        }

        [TestMethod]
        public void TestNull()
        {
            var converter = new ContainsConverter();
            var array = new string[] { "Test" };
            Assert.AreEqual(false, converter.Convert(new object[] { array, null }, null, null, null));
        }
    }
}
