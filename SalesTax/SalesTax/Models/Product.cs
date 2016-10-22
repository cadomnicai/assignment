using SalesTax.Constants;
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
            get { return Math.Round(Price + SalesTax, 2); }           
        }

        public abstract void CalculateTax();
    }
}
