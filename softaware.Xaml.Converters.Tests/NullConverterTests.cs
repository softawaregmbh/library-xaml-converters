using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace softaware.Xaml.Converters.Tests
{
    [TestClass]
    public class NullConverterTests
    {
        [TestMethod]
        public void TestNullConverter()
        {
            var converter = new NullConverter();
            converter.TreatEmptyStringAsNull = false;

            Assert.AreEqual(true, converter.Convert(null, null, null, null));
            Assert.AreEqual(false, converter.Convert(1, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object(), null, null, null));
            Assert.AreEqual(false, converter.Convert(string.Empty, null, null, null));

            converter.TreatEmptyStringAsNull = true;

            Assert.AreEqual(true, converter.Convert(null, null, null, null));
            Assert.AreEqual(false, converter.Convert(1, null, null, null));
            Assert.AreEqual(false, converter.Convert(new object(), null, null, null));
            Assert.AreEqual(true, converter.Convert(string.Empty, null, null, null));
        }
    }
}
