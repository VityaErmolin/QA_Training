using System;
using System.Collections.Generic;
using System.Text;
using Core.Discounts;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    class Discount_5Test
    {
        [Test]
        public void PercentageValue_5PercentOf100_Return95()
        {
            // Arrange
            decimal expected = 95;

            // Act
            decimal actual = new Discount_5().PercentageValue(100);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
