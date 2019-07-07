using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
    }

    internal enum FileErrorInfo
    {
        File,
        Path,
        None
    }
}
