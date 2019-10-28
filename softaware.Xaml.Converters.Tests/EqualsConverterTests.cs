using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace softaware.Xaml.Converters.Tests
{
    [TestClass]
    public class EqualsConverterTests
    {
        [TestMethod]
        public void TestValueType()
        {
            var converter = new EqualsConverter();

            Assert.AreEqual(true, converter.Convert(true, null, true, null));
            Assert.AreEqual(true, converter.Convert(false, null, false, null));

            Assert.AreEqual(false, converter.Convert(true, null, false, null));
            Assert.AreEqual(false, converter.Convert(false, null, true, null));
        }

        [TestMethod]
        public void TestReferenceType()
        {
            var converter = new EqualsConverter();

            var o1 = new object();
            var o2 = new object();

            Assert.AreEqual(true, converter.Convert(o1, null, o1, null));
            Assert.AreEqual(true, converter.Convert(o2, null, o2, null));

            Assert.AreEqual(false, converter.Convert(o1, null, o2, null));
            Assert.AreEqual(false, converter.Convert(o2, null, o1, null));
        }

        [TestMethod]
        public void TestCustomObject()
        {
            var converter = new EqualsConverter();

            var t1 = new Test() { Value = 1 };
            var t2 = new Test() { Value = 1 };
            var t3 = new Test() { Value = 2 };

            Assert.AreEqual(true, converter.Convert(t1, null, t1, null));
            Assert.AreEqual(true, converter.Convert(t1, null, t2, null));
            Assert.AreEqual(false, converter.Convert(t1, null, t3, null));
        }

        private class Test
        {
            public int Value { get; set; }

            public override bool Equals(object obj)
            {
                var test = obj as Test;
                return test != null && test.Value == this.Value;
            }

            public override int GetHashCode()
            {
                return this.Value;
            }
        }
    }
}
