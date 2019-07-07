using Ignite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteTest.ValidatorTest
{
    [TestClass]
    public class ValidateBinaryNumber
    {
        internal Validator Validator { get; } = new Validator();

        [TestMethod]
        public void ValidateBinaryNumber_BadData_False()
        {
            var data = "123";
            var wanted = false;

            var result = Validator.ValidateBinaryNumber(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void ValidateBinaryNumber_EmptyData_False()
        {
            string data = null;
            var wanted = false;

            var result = Validator.ValidateBinaryNumber(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void ValidateBinaryNumber_WellData_True()
        {
            var data = "01001";
            var wanted = true;

            var result = Validator.ValidateBinaryNumber(data);

            Assert.AreEqual(wanted, result);
        }
    }
}
