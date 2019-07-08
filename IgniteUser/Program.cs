using System;
using Ignite;

namespace IgniteUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ignite! This is an example console application to see how it works!\n\n");

            Console.WriteLine("Some instructions:\n" +
                "\n-When you write the file name, don't include its extension, eg: MyExcelFile" +
                "\n\n-Output file will be created at the same source file directory" +
                "\n\n-If destination file name already exists, it'll be overwrited\n\n");

            Console.Write("Okay, give me some information, please\n\n" +
                "Source file name: ");
            string sourceFile = Console.ReadLine();

            Console.Write("Source file path: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Output file name: ");
            string destionationFile = Console.ReadLine();

            string result = new Controller(sourceFile, sourcePath, destionationFile).ConvertNumericTypes();

            Console.WriteLine("\n\n" + result);
        }
    }
}
