using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IgniteTest.FileProcessorTest
{
    [TestClass]
    public class ExtractDataFromFile : FileProcessor
    {
        readonly string executionDirectory, currentDirectory;

        public ExtractDataFromFile()
        {
            executionDirectory = Environment.CurrentDirectory;
            string binDirectory = Directory.GetParent(executionDirectory).Parent.FullName;
            currentDirectory = Directory.GetParent(binDirectory).FullName;
        }

        [TestMethod]
        public void WellData_ExtractInfo()
        {
            var fileInfo = Path.Combine(currentDirectory, @"TestData");

            var result = Processor.ExtractDataFromFile("DataTest.xlsx", fileInfo);

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void WrongPath_ExtractInfo()
        {
            var fileInfo = Path.Combine(currentDirectory, @"I am not exit");

            var result = Processor.ExtractDataFromFile("DataTest.xlsx", fileInfo);

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void WrongFile_ExtractInfo()
        {
            var fileInfo = Path.Combine(currentDirectory, @"TestData");

            var result = Processor.ExtractDataFromFile("DataTest.png", fileInfo);

            Assert.IsTrue(result == null);
        }
    }
}
