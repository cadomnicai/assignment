using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using SalesTax.Models;
using SalesTax;
using SalesTax.Enums;

namespace Tests
{
    [TestFixture]
    public class SalesTaxCalculatorTests
    {
        [Test]
        public void FirstExample()
        {
            var products = new List<Product>() {
                Factory.CreateProduct(Type.Magazines,"Magazine", 10.49m),
                Factory.CreateProduct(Type.None,"Shirt", 34.99m),
                Factory.CreateProduct(Type.Food,"Package of milk", 0.85m)            
            };

            var receiptDetails = SalesTaxCalculator.Process(products);
            var receiptItems = receiptDetails.ReceiptItems.ToList();
         
            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(10.49m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(40.24m));
            Assert.That(receiptItems[2].PriceIncludingSalesTax, Is.EqualTo(0.85m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(5.25m));
            Assert.That(receiptDetails.Total, Is.EqualTo(51.58m));
        }

        [Test]
        public void SecondExample()
        {
            var products = new List<Product>() {
                Factory.CreateProduct(Type.Food,"Imported box of chocolates", 10m, true),
                Factory.CreateProduct(Type.None,"Imported bottle of perfume", 47.50m, true)               
            };

            var receiptDetails = SalesTaxCalculator.Process(products);
            var receiptItems = receiptDetails.ReceiptItems.ToList();
          
            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(11.00m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(59.38m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(12.88m));
            Assert.That(receiptDetails.Total, Is.EqualTo(70.38m));
        }

        [Test]
        public void ThirdExample()
        {
            var products = new List<Product>() {
                Factory.CreateProduct(Type.None,"Imported bottle of perfume", 27.99m, true),
                Factory.CreateProduct(Type.None,"Bottle of perfume", 18.99m),
                Factory.CreateProduct(Type.Electronics,"USB drive", 9.75m),
                Factory.CreateProduct(Type.Food,"Box of imported chocolates", 11.25m, true),
            };

            var receiptDetails = SalesTaxCalculator.Process(products);
            var receiptItems = receiptDetails.ReceiptItems.ToList();
                     
            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(34.99m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(21.84m));
            Assert.That(receiptItems[2].PriceIncludingSalesTax, Is.EqualTo(9.75m));
            Assert.That(receiptItems[3].PriceIncludingSalesTax, Is.EqualTo(12.38m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(10.97m));
            Assert.That(receiptDetails.Total, Is.EqualTo(78.95m));// it will fail , should be 78.96
        }
    }
}
