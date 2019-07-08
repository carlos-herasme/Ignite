using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IgniteTest.FileProcessorTest
{
    [TestClass]
    public class GenerateFileData : FileProcessor
    {
        readonly string executionDirectory, currentDirectory;

        public GenerateFileData()
        {
            executionDirectory = Environment.CurrentDirectory;
            string binDirectory = Directory.GetParent(executionDirectory).Parent.FullName;
            currentDirectory = Directory.GetParent(binDirectory).FullName;
        }

        [TestMethod]
        public void WellData_True()
        {
            var path = Path.Combine(currentDirectory, @"TestData");
            var file = "DataTest.xlsx";
            var generatedFile = "DataResultTest";

            var extractedData = Processor.ExtractDataFromFile(file, path);

            var result = Processor.GenerateFileData(extractedData, generatedFile, path);

            Assert.IsTrue(result);
        }
    }
}
