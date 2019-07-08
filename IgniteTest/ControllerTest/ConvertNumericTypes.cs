using Ignite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IgniteTest.ControllerTest
{
    [TestClass]
    public class ConvertNumericTypes
    {
        Controller controller;
        readonly string executionDirectory, currentDirectory;

        public ConvertNumericTypes()
        {
            executionDirectory = Environment.CurrentDirectory;
            string binDirectory = Directory.GetParent(executionDirectory).Parent.FullName;
            currentDirectory = Directory.GetParent(binDirectory).FullName;
        }

        [TestMethod]
        public void WellPathAndFileName_OkMessage()
        {
            var sourceFileName = "DataTest";
            var sourceFilePath = currentDirectory + @"\TestData";
            var destionationFileName = "DataTransformed";
            controller = new Controller(sourceFileName, sourceFilePath, destionationFileName);

            controller.ConvertNumericTypes();
        }
    }
}
