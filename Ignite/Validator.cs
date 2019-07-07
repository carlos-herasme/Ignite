using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

[assembly: InternalsVisibleTo("IgniteTest")]
namespace Ignite
{
    internal class Validator
    {
        internal (bool Result, string FileErrorInfoMessage) ValidateFileInfo(string fileName, string filePath)
        {
            bool wellFileInfo = true;
            FileErrorInfo fileError = FileErrorInfo.None;


            if (!Directory.Exists(filePath))
            {
                wellFileInfo = false;
                fileError =  FileErrorInfo.Path;
            }
            else if (!File.Exists(fileName))
            {
                wellFileInfo = false;
                fileError = FileErrorInfo.File;
            }

            string fileErrorInfoMessage;

            if (fileError == FileErrorInfo.None)
                fileErrorInfoMessage = "Without errors";
            else
            {
                fileErrorInfoMessage = fileError == FileErrorInfo.File
                    ? "The information provided about the file name/extension is wrong."
                    : "The information provided about the file directory is wrong.";
            }

            return (wellFileInfo, fileErrorInfoMessage);
        }

        /// <summary>
        /// Validate if a given argument is a hexadecimal number.
        /// </summary>
        /// <param name="number">Argument to evaluate</param>
        /// <returns></returns>
        internal bool ValidateHexNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;

            number = number.ToUpper();

            var allowedChars = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
            };

            return ValidateData(allowedChars, number);
        }

        /// <summary>
        /// Validate if a given argument is a binary number.
        /// </summary>
        /// <param name="number">Number to validate</param>
        /// <returns></returns>
        internal bool ValidateBinaryNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;

            var allowedChars = new List<char>()
            {
                '0', '1'
            };

            return ValidateData(allowedChars, number);
        }

        /// <summary>
        /// Validate if a giben argument is a decimal number.
        /// </summary>
        /// <param name="number">Number to validate</param>
        /// <returns></returns>
        internal bool ValidateDecimalNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;
            if (number.Length >= 17)
                return false;

            return long.TryParse(number, out long result);
        }
                
        private bool ValidateData(List<char> allowedData, string data)
        {
            bool result = true;

            data.ToList().ForEach(n =>
            {
                if (!allowedData.Contains(n))
                    result = false;
            });

            return result;
        }
    }

    internal enum FileErrorInfo
    {
        File,
        Path,
        None
    }
}
