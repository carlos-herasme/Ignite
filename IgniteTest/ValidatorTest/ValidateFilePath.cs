using Ignite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IgniteTest.ValidatorTest
{
    [TestClass]
    public class ValidateFilePath
    {
        internal Validator Validator { get; } = new Validator();
        readonly string executionDirectory, currentDirectory;

        public ValidateFilePath()
        {
            executionDirectory = Environment.CurrentDirectory;
            string binDirectory = Directory.GetParent(executionDirectory).Parent.FullName;
            currentDirectory = Directory.GetParent(binDirectory).Parent.FullName;
        }

        [TestMethod]
        public void ValidateFilePath_NonExistingPath_False()
        {
            var fileName = "rojo";
            var filePath = "azul";
            var wanted = false;

            var (result, errorMessage) = Validator.ValidateFileInfo(fileName, filePath);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void ValidateFilePath_BadFile_False()
        {
            var fileName = "rojo";
            var filePath = Path.Combine(currentDirectory, @"TestData");
            var wanted = false;

            var (result, errorMessage) = Validator.ValidateFileInfo(fileName, filePath);

            Assert.AreEqual(wanted, result);
        }

        [TestMethod]
        public void ValidateFilePath_WellData_True()
        {
            var fileName = "Test.xlsx";
            var filePath = Path.Combine(currentDirectory, @"TestData");
            var wanted = false;

            var (result, errorMessage) = Validator.ValidateFileInfo(fileName, filePath);

            Assert.AreEqual(wanted, result);
        }
    }
}
