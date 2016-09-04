using SalesTax.Enums;

namespace SalesTax.Models
{
    public class ReceiptItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CategoryEnum? Category { get; set; }
        public bool IsImported { get; set; }
        public decimal PriceIncludingSalesTax { get; set; }
        public decimal SalesTax { get; set;}
    }
}
