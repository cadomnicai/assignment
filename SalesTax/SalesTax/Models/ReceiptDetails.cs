using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Models
{
    public class ReceiptDetails
    {
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
        public List<Product> ReceiptItems { get; set; }
    }
}
