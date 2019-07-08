using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteTest.NumericConverterTest
{
    [TestClass]
    public class ConvertToOctal : NumericConverter
    {
        [TestMethod]
        public void BadData_Null()
        {
            var data = "213asd";
            string wanted = null;

            var result = Converter.ConvertToOctal(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void HexNumber_HexResult()
        {
            var data = "AD12";
            string wanted = "126422";

            var result = Converter.ConvertToOctal(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void DecimalNumber_OctalResult()
        {
            var data = "668";
            string wanted = "1234";

            var result = Converter.ConvertToOctal(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void BinaryNumber_HexResult()
        {
            var data = "10010101";
            string wanted = "225";

            var result = Converter.ConvertToOctal(data);

            Assert.AreEqual(wanted, result);
        }
    }
}
