using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteTest.NumericConverterTest
{
    [TestClass]
    public class ConvertToDecimal : NumericConverter
    {
        [TestMethod]
        public void BadData_Null()
        {
            var data = "213asd";
            string wanted = null;

            var result = Converter.ConvertToDecimal(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void HexNumber_DecimalResult()
        {
            var data = "a";
            string wanted = "10";

            var result = Converter.ConvertToDecimal(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void DecimalNumber_DecimalResult()
        {
            var data = "231";
            string wanted = "231";

            var result = Converter.ConvertToDecimal(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void BinaryNumber_DecimalResult()
        {
            var data = "01001";
            string wanted = "9";

            var result = Converter.ConvertToDecimal(data);

            Assert.AreEqual(wanted, result);
        }
    }
}

