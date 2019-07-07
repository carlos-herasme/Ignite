using Ignite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteTest.ValidatorTest
{
    [TestClass]
    public class ValidateHexNumber
    {
        internal Validator Validator { get; } = new Validator();

        [TestMethod]
        public void EmptyData_False()
        {
            var data = "";
            var wanted = false;

            var result = Validator.ValidateHexNumber(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void BadData_False()
        {
            var data = "@aksdnjL";
            var wanted = false;

            var result = Validator.ValidateHexNumber(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void WellData_True()
        {
            var data = "F1876C";
            var wanted = true;

            var result = Validator.ValidateHexNumber(data);

            Assert.AreEqual(wanted, result);
        }
    }
}
