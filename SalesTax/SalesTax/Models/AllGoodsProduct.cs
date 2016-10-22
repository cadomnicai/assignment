using SalesTax.Constants;

namespace SalesTax.Models
{
    public class AllGoodsProduct : Product
    {
        public AllGoodsProduct(string name, decimal price, bool? isImported)
            : base(name, price, isImported) { }
        public override void CalculateTax()
        {
            SalesTax += Price * Taxes.All;            
        }
    }
}
