using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SalesTax.Models;
using SalesTax.Enums;

namespace SalesTax.Tests
{
    [TestFixture]
    public class SalesTaxCalculatorTests
    {
        
        [Test]
        public void FirstExample()
        {
            var products = new List<Product>() {
                new Product("Magazine", 10.49m, CategoryEnum.Magazines),
                new Product("Shirt", 34.99m),
                new Product("Package of milk", 0.85m, CategoryEnum.Food)
            };

            var salesTaxCalculator = new SalesTaxCalculator();
            var receiptDetails = salesTaxCalculator.Process(products);

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
                new Product("Imported box of chocolates", 10m, CategoryEnum.Food, true),
                new Product("Imported bottle of perfume", 47.50m, isImported: true)
            };

            var salesTaxCalculator = new SalesTaxCalculator();

            var receiptDetails = salesTaxCalculator.Process(products);


            var receiptItems = receiptDetails.ReceiptItems.ToList();

            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(11.00m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(59.38m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(12.88m));
            Assert.That(receiptDetails.Total, Is.EqualTo(70.38m));
        }

        [Test]
        public void ThirdExample()
        {
            var products = new List<Product>()
            {
                new Product("Imported bottle of perfume", 27.99m, isImported: true),
                new Product("Bottle of perfume", 18.99m),
                new Product("USB drive", 9.75m, CategoryEnum.Electronics),
                new Product("Box of imported chocolates", 11.25m, CategoryEnum.Food, true)
            };

            var salesTaxCalculator = new SalesTaxCalculator();

            var receiptDetails = salesTaxCalculator.Process(products);

            var receiptItems = receiptDetails.ReceiptItems.ToList();

            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(34.99m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(21.84m));
            Assert.That(receiptItems[2].PriceIncludingSalesTax, Is.EqualTo(9.75m));
            Assert.That(receiptItems[3].PriceIncludingSalesTax, Is.EqualTo(12.38m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(10.97m));

            //Assert.That(receiptDetails.Total, Is.EqualTo(78.95m)); should be 78.96m 
            Assert.That(receiptDetails.Total, Is.EqualTo(78.96m));
        }
    }
}