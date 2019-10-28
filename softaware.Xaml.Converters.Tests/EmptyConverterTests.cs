using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace softaware.Xaml.Converters.Tests
{
    [TestClass]
    public class EmptyConverterTests
    {
        [TestMethod]
        public void TestEmptyConverter()
        {
            var converter = new EmptyConverter();
            
            converter.TreatNullAsEmpty = false;
            
            Assert.AreEqual(false, converter.Convert(null, null, null, null));
            Assert.AreEqual(true, converter.Convert(string.Empty, null, null, null));
            Assert.AreEqual(true, converter.Convert(new object[0], null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { new object() }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { new object(), new object() }, null, null, null));
            
            converter.TreatNullAsEmpty = true;

            Assert.AreEqual(true, converter.Convert(null, null, null, null));
            Assert.AreEqual(true, converter.Convert(string.Empty, null, null, null));
            Assert.AreEqual(true, converter.Convert(new object[0], null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { new object() }, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object[] { new object(), new object() }, null, null, null));
        }
    }
}
