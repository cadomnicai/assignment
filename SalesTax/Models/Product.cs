using SalesTax.Enums;

namespace SalesTax.Models
{
    public class Product
    {
        public Product(string name, decimal price, CategoryEnum? category = null, bool? isImported = null)
        {
            Name = name;
            Price = price;
            Category = category;
            IsImported = isImported ?? false;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public CategoryEnum? Category { get; set; }
        public bool IsImported { get; set; }
    }
}
