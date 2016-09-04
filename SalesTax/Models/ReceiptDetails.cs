using System.Collections.Generic;

namespace SalesTax.Models
{
    public class ReceiptDetails
    {
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
        public List<ReceiptItem> ReceiptItems { get; set; }
    }
}
