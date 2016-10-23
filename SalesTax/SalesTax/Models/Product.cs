using SalesTax.Constants;
using SalesTax.Utils;
using System;

namespace SalesTax.Models
{
    public abstract class Product
    {
        protected Product(string name, decimal price, bool? isImported)
        {
            Name = name;
            Price = price;
            IsImported = isImported ?? false;
           
            if (IsImported)
                SalesTax += Price * Taxes.Import;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }        

        public bool IsImported { get; set; }

        public decimal SalesTax { get; set; }

        public decimal PriceIncludingSalesTax
        {
            get { return Format.RoundTo2d(Price + SalesTax); }           
        }

        public abstract void CalculateTax();
    }
}
