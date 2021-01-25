using System;
using System.Collections.Generic;
using System.Text;
using Core.Discounts;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    class Discount_1Test
    {
        [Test]
        public void PercentageValue_1PercentOf100_Return99()
        {
            // Arrange
            decimal expected = 99;

            // Act
            decimal actual = new Discount_1().PercentageValue(100);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
