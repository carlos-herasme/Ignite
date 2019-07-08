using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ExcelDataReader;
using IronXL;
using System.Linq;
using ClosedXML.Excel;
using System.Data;

namespace Ignite
{
    internal class FileProcessor
    {
        Validator validator;

        public FileProcessor() => validator = new Validator();

        internal List<NumericInfo> ExtractDataFromFile(string file, string path)
        {
            if (validator.ValidateFileInfo(file, path).Result)
            {
                var fileDataRows = new List<NumericInfo>();

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var stream = File.Open($@"{path}\{file}", FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        try
                        {
                            do
                            {
                                while (reader.Read())
                                {
                                    fileDataRows.Add(new NumericInfo()
                                    {
                                        Value = reader.GetValue(0).ToString(),
                                        SourceType = IdenfityNumericType(reader.GetValue(1).ToString()),
                                        DestionationType = IdenfityNumericType(reader.GetValue(2).ToString()),
                                        ConvertionValue = null
                                    });
                                }
                            } while (reader.NextResult());
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }

                        fileDataRows.RemoveAt(0);
                    }
                }

                return fileDataRows;
            }
            else
            {
                return null;
            }
        }

        internal bool GenerateFileData(List<NumericInfo> numericInfo, string file, string path)
        {
            try
            {
                if (numericInfo.Count == 0)
                    return false;

                var table = new DataTable();

                table.Columns.AddRange(new DataColumn[4]
                {
                    new DataColumn("Value", typeof(string)),
                    new DataColumn("Source Type", typeof(string)),
                    new DataColumn("Source Destination", typeof(string)),
                    new DataColumn("Convertion Value", typeof(string))
                });

                foreach (var convertedItem in numericInfo)
                {
                    table.Rows.Add
                        (
                            convertedItem.Value,
                            convertedItem.SourceType,
                            convertedItem.DestionationType,
                            convertedItem.ConvertionValue
                        );
                }

                using (var wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(table, "Info");
                    wb.SaveAs($@"{path}\{file}.xlsx");
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal NumericType IdenfityNumericType(string type)
        {
            if (Enum.TryParse(type, out NumericType numericType))
                return numericType;
            return NumericType.None;
        }
    }
}
