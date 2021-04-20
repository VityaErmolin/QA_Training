using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using Task150.Model;
using Task150.Pages;

namespace Task150.Tests
{
    public class AddProductToCartTest :TestBase
    {
        [AllureSubSuite("CanAddProductToCartTest")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/VityaErmolin/QA_Training")]
        [AllureTest("This test add 3 product to cart")]
        [AllureOwner("Viktor Ermolin")]
        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsersWithCustomEmail")]
        public void CanAddProductToCartTest(User user)
        {
            //Login
            var authenticationPage = new AuthenticationPage(_driver).Open();
            Assert.True(authenticationPage.IsThisPage(), "This is not authentication page!");

            var myAccountPage = authenticationPage.FillEmailAndPassword(user.Email, user.Password)
                .LoginButtonClick();
            Assert.True(myAccountPage.IsThisPage(), "This is not authentication page!");

            var cartPage = myAccountPage.MenuHeader.CartButtonClick();
            Assert.True(cartPage.IsThisPage(), "This is not cart page!");

            cartPage.CleanCart();
            Assert.True(cartPage.IsEmpty(), "Cart is not empty");

            var womenProductPage = cartPage.MenuHeader.WomenTabClick();
            womenProductPage.AddedThreeProductToCart();

            cartPage = womenProductPage.MenuHeader.CartButtonClick();
            
            Assert.False(cartPage.IsEmpty(), "Cart is not empty");
            Assert.AreEqual(cartPage.GetCountProducts(),3);
        }
    }
}
