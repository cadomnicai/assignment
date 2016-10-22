using SalesTax.Constants;

namespace SalesTax.Models
{
    public class FoodProduct : Product
    {
        public FoodProduct(string name, decimal price, bool? isImported)
            : base(name, price, isImported) { }
        public override void CalculateTax()
        {
            SalesTax += Price * Taxes.None;
        }
    }
}
