using SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class SalesTaxCalculator
    {
        public ReceiptDetails ReceiptDetails { get; set; }
        public ReceiptItemCalculator ProductTaxCalculator { get; set; }

        public SalesTaxCalculator()
        {
            ReceiptDetails = new ReceiptDetails();
            ReceiptDetails.ReceiptItems = new List<ReceiptItem>();

            ProductTaxCalculator = new ReceiptItemCalculator();
        }

        public ReceiptDetails Process(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
               var receiptItem = ProductTaxCalculator.Compute(product);

                ReceiptDetails.ReceiptItems.Add(receiptItem);

                ReceiptDetails.SalesTax += receiptItem.SalesTax;
                ReceiptDetails.Total += receiptItem.PriceIncludingSalesTax;
            }

            return ReceiptDetails;
        }
    }
}
