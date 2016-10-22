using SalesTax.Constants;

namespace SalesTax.Models
{
    public class ElectronicsProduct : Product
    {
        public ElectronicsProduct(string name, decimal price, bool? isImported)
            : base(name, price, isImported) { }
        public override void CalculateTax()
        {
            SalesTax += Price * Taxes.None;
        }
    }
}
