using System;
using System.Collections.Generic;
using System.Text;
using Core.Discounts;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    class ValueCalculatorTest
    {
        private IEnumerable<Product> Products;
        private ICalculate Calculate;
        
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
        }
        [Test]
        public void ValueCalc_SumAllProducts_Return100()
        {
            // Arrange
            decimal expected = 100;

            // Act
            decimal actual =Calculate.ValueCalc(Products);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}