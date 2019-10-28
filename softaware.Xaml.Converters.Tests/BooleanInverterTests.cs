using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace softaware.Xaml.Converters.Tests
{
    [TestClass]
    public class BooleanInverterTests
    {
        [TestMethod]
        public void TestBooleanInverter()
        {
            var converter = new BooleanInverter();

            Assert.AreEqual(false, converter.Convert(true, null, null, null));
            Assert.AreEqual(true, converter.Convert(false, null, null, null));

            Assert.AreEqual(true, converter.ConvertBack(false, null, null, null));
            Assert.AreEqual(false, converter.ConvertBack(true, null, null, null));
        }
    }
}
