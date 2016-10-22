using SalesTax.Constants;

namespace SalesTax.Models
{
    public class MagazinesProduct : Product
    {
        public MagazinesProduct(string name, decimal price, bool? isImported)
            : base(name, price, isImported) { }
        public override void CalculateTax()
        {
            SalesTax += Price * Taxes.None;
        }
    }
}
