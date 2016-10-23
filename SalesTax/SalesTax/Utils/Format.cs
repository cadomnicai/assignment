using System;

namespace SalesTax.Utils
{
    public static class Format
    {
        public static decimal RoundTo2d(decimal val)
        {
            return Math.Round(val, 2);
        }
    }
}
