using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Ignite
{
    public class Controller
    {
        readonly Validator validator;
        string sourceFileName, sourceFilePath, destionationFileName;

        public Controller(string sourceFileName, string sourceFilePath, string destionationFileName)
        {
            validator = new Validator();

            this.sourceFileName = sourceFileName + ".xlsx";
            this.sourceFilePath = sourceFilePath;
            this.destionationFileName = destionationFileName + ".xlsx";

            if (!validator.ValidateFileInfo(this.sourceFileName, this.sourceFilePath).Result)
                throw new FileNotFoundException("Non existing source file info. Verify if it's really exists.");
        } 

        public string ConvertNumericTypes()
        {
            var fileProcessor = new FileProcessor();

            var fileData = fileProcessor.ExtractDataFromFile(sourceFileName, sourceFilePath);
            ConvertDestionationValue(fileData);

            if (fileProcessor.GenerateFileData(fileData, destionationFileName, sourceFilePath))
                return "Convertion completed.";
            else
                return "An error was found. Operation could not be completed.";
        }

        private void ConvertDestionationValue(List<NumericInfo> originalData)
        {
            var converter = new NumericConverter();

            foreach (var row in originalData)
            {
                switch (row.DestionationType)
                {
                    case NumericType.Binary:
                        row.ConvertionValue = converter.ContertToBinary(row.Value);
                        break;
                    case NumericType.Decimal:
                        row.ConvertionValue = converter.ConvertToDecimal(row.Value);
                        break;
                    case NumericType.Hex:
                        row.ConvertionValue = converter.ConvertToHex(row.Value);
                        break;
                    case NumericType.Octal:
                        row.ConvertionValue = converter.ConvertToOctal(row.Value);
                        break;
                    default:
                        row.ConvertionValue = row.Value;
                        break;
                }
            }
        }
    }
}
