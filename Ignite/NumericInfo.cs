using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite
{
    public class NumericInfo
    {
        public string Value { get; set; }
        public NumericType SourceType { get; set; }
        public NumericType DestionationType { get; set; }
        public string ConvertionValue { get; set; }
    }

    public enum NumericType
    {
        Binary,
        Decimal,
        Hex,
        Octal,
        None
    }
}
