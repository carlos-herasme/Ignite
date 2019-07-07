using Ignite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteTest.ValidatorTest
{
    [TestClass]
    public class ValidateDecimalNumber
    {
        internal Validator Validator { get; } = new Validator();

        [TestMethod]
        public void EmptyData_False()
        {
            var data = "";
            var wanted = false;

            var result = Validator.ValidateDecimalNumber(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void BadData_False()
        {
            var data = "asdk1298";
            var wanted = false;

            var result = Validator.ValidateDecimalNumber(data);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void WellData_True()
        {
            var data = "5619123";
            var wanted = true;

            var result = Validator.ValidateDecimalNumber(data);

            Assert.AreEqual(wanted, result);
        }
    }
}
