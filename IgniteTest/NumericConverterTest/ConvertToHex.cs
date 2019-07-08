using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteTest.NumericConverterTest
{
    [TestClass]
    public class ConvertToHex : NumericConverter
    {
        [TestMethod]
        public void BadData_Null()
        {
            var data = "213asd";
            string wanted = null;

            var result = Converter.ConvertToHex(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void HexNumber_HexResult()
        {
            var data = "a";
            string wanted = "A";

            var result = Converter.ConvertToHex(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void DecimalNumber_HexResult()
        {
            var data = "253";
            string wanted = "FD";

            var result = Converter.ConvertToHex(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void BinaryNumber_HexResult()
        {
            var data = "11101";
            string wanted = "1D";

            var result = Converter.ConvertToHex(data);

            Assert.AreEqual(wanted, result);
        }
    }
}
