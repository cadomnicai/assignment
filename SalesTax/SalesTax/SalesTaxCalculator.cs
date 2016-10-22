using SalesTax.Models;
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
            ReceiptDetails.ReceiptItems = new List<Product>();
        }
        public static ReceiptDetails Process(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                ReceiptDetails.ReceiptItems.Add(product);
                ReceiptDetails.SalesTax += Math.Round(product.SalesTax,2);
                ReceiptDetails.Total += Math.Round(product.PriceIncludingSalesTax, 2);                
            }

            return ReceiptDetails;
        }
    }
}
