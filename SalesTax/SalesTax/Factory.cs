using SalesTax.Models;
using SalesTax.Enums;

namespace SalesTax
{
    public static class Factory
    {
        public static Product CreateProduct(Type type, string name, 
            decimal price, bool? isImported = null)
        {
            Product product = null;

            switch (type)
            {
                case Type.None:
                    product = new AllGoodsProduct(name, price, isImported);
                    break;
                case Type.Magazines:
                    product = new MagazinesProduct(name, price, isImported);
                    break;
                case Type.Food:
                    product = new FoodProduct(name, price, isImported);
                    break;
                case Type.Electronics:
                    product = new ElectronicsProduct(name, price, isImported);
                    break;
            }

            product.CalculateTax();

            return product;
        }
    }
}
