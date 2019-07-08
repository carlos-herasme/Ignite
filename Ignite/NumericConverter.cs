using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("IgniteTest")]
namespace Ignite
{
    internal class NumericConverter
    {
        Validator validator;

        public NumericConverter()
        {
            validator = new Validator();
        }

        internal string ContertToBinary(string number)
        {
            if (validator.ValidateBinaryNumber(number))
                return number;
            else if (validator.ValidateDecimalNumber(number))
                return Convert.ToString(Convert.ToInt64(number), 2);
            else if(validator.ValidateHexNumber(number))
                return Convert.ToString(Convert.ToInt32(number, 16), 2);

            return null;
        }

        internal string ConvertToDecimal(string number)
        {
            if (validator.ValidateBinaryNumber(number))
                return Convert.ToInt64(number.ToString(), 2).ToString();
            else if (validator.ValidateDecimalNumber(number))
                return number;
            else if (validator.ValidateHexNumber(number))
                return Convert.ToInt32(number.ToString(), 16).ToString();

            return null;
        }

        internal string ConvertToHex(string number)
        {
            if (validator.ValidateBinaryNumber(number))
                return Convert.ToString(Convert.ToInt64(number, 2), 16).ToUpper();
            else if (validator.ValidateDecimalNumber(number))
                return Convert.ToString(Convert.ToInt64(number), 16).ToUpper();
            else if (validator.ValidateHexNumber(number))
                return number.ToUpper();

            return null;
        }

        internal string ConvertToOctal(string number)
        {
            if (validator.ValidateBinaryNumber(number))
                return Convert.ToString(Convert.ToInt64(number, 2), 8).ToUpper();
            else if (validator.ValidateDecimalNumber(number))
                return Convert.ToString(Convert.ToInt64(number), 8).ToUpper();
            else if (validator.ValidateHexNumber(number))
                return Convert.ToString(Convert.ToInt32(number.ToString(), 16), 8).ToString(); ;

            return null;
        }
    }
}
