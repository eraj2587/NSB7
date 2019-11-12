using System;

namespace WUBS.Utilities.Common
{
    public static class DecimalExtensions
    {
        public static byte GetSignificantDigitsAfterDecimalPoint(this decimal value)
        {
            byte significantDigits = 0;
            while (value * (decimal)Math.Pow(10, significantDigits) != Math.Round(value * (decimal)Math.Pow(10, significantDigits)))
                significantDigits++;

            return significantDigits;
        }
    }
}