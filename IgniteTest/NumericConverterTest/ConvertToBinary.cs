using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteTest.NumericConverterTest
{
    [TestClass]
    public class ConvertToBinary : NumericConverter
    {
        [TestMethod]
        public void BadData_Null()
        {
            var data = "213asd";
            string wanted = null;

            var result = Converter.ContertToBinary(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void HexNumber_BinaryResult()
        {
            var data = "d";
            string wanted = "1101";

            var result = Converter.ContertToBinary(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void DecimalNumber_BinaryResult()
        {
            var data = "2";
            string wanted = "10";

            var result = Converter.ContertToBinary(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void BinaryNumber_BinaryResult()
        {
            var data = "01001";
            string wanted = "01001";

            var result = Converter.ContertToBinary(data);

            Assert.AreEqual(wanted, result);
        }
    }
}
