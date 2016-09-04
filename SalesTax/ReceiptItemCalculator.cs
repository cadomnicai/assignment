using SalesTax.Models;
using SalesTax.ValueObjects;
using System;

namespace SalesTax
{
    public class ReceiptItemCalculator
    {
        public ReceiptItem ReceiptItem;


        public ReceiptItem Compute(Product product)
        {
            SetData(product);

            ApplyTax();

            return ReceiptItem;
        }

        public void SetData(Product product)
        {
            ReceiptItem = new ReceiptItem();

            ReceiptItem.Name = product.Name;
            ReceiptItem.IsImported = product.IsImported;
            ReceiptItem.Category = product.Category;
            ReceiptItem.Price = product.Price;
        }

     
        public void ApplyTax()
        {
            var tax = TaxValues.None;
            
            if (ReceiptItem.IsImported) tax = TaxValues.Import;

            if (ReceiptItem.Category == null) tax += TaxValues.AllGoods;

            var salesTax = ReceiptItem.Price * tax / 100;
            ReceiptItem.SalesTax += Math.Round(salesTax, 2);

            ReceiptItem.PriceIncludingSalesTax += Math.Round(ReceiptItem.Price + salesTax, 2);

        }
    }
}
