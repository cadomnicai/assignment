using SalesTax.Models;
using SalesTax.Utils;
using System;
using System.Collections.Generic;

namespace SalesTax
{
    public static class SalesTaxCalculator
    {
        static ReceiptDetails ReceiptDetails = null;
        static SalesTaxCalculator()
        {
            ReceiptDetails = new ReceiptDetails();
        }
        public static ReceiptDetails Process(IEnumerable<Product> products)
        {
            ResetValues();

            foreach (var product in products)
            {
                ReceiptDetails.ReceiptItems.Add(product);
                ReceiptDetails.SalesTax += Format.RoundTo2d(product.SalesTax);
                ReceiptDetails.Total += Format.RoundTo2d(product.PriceIncludingSalesTax);                
            }

            return ReceiptDetails;
        }

        private static void ResetValues()
        {
            ReceiptDetails.ReceiptItems = new List<Product>();
            ReceiptDetails.SalesTax = 0m;
            ReceiptDetails.Total = 0m;
        }
    }
}
