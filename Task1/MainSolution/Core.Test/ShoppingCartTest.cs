using System;
using System.Collections.Generic;
using System.Text;
using Core.Discounts;
using NUnit;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    class ShoppingCartTest
    {
        private IEnumerable<Product> Products;
        private ICalculate Calculate;
        private IPercentage Discount_1;
        private IPercentage Discount_5;

      
        [SetUp]
        public void Initialization()
        {
            Products = new List<Product>()
            {
                new Product() {ProductID = 1, Name = "Milk", Price = 25},
                new Product() {ProductID = 2, Name = "Bread", Price = 35},
                new Product() {ProductID = 3, Name = "Chocolate", Price = 40},
            };
            Calculate = new ValueCalculator();
            Discount_1 = new Discount_1();
            Discount_5 = new Discount_5();
        }

        [Test]
        public void CalculateTotal_DisCount1BySum100_Return99()
        {
            var ShoppingCart = new ShoppingCart( Discount_1, Calculate);
            ShoppingCart.Products = Products;

            // Arrange
            decimal expected = 99;

            // Act
            decimal actual = ShoppingCart.CalculateTotal();

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void CalculateTotal_DisCount5BySum100_Return95()
        {
            var ShoppingCart = new ShoppingCart(Discount_5, Calculate);
            ShoppingCart.Products = Products;

            // Arrange
            decimal expected = 95;

            // Act
            decimal actual = ShoppingCart.CalculateTotal();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
