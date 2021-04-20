﻿using System.Threading;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using Task150.Model;
using Task150.Pages;

namespace Task150.Tests
{
    [TestFixture]
    public class AddProductYourWishlistTest : TestBase
    {
        [AllureSubSuite("CanAddProductYourWishlist")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/VityaErmolin/QA_Training")]
        [AllureTest("This test create and add product to your wishlist")]
        [AllureOwner("Viktor Ermolin")]

        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsersWithCustomEmail")]
        public void CanAddProductYourWishlist(User user)
        {
            //Login
            var authenticationPage = new AuthenticationPage(_driver).Open();
            Assert.True(authenticationPage.IsThisPage(), "This is not authentication page!");

            var myAccountPage = authenticationPage.FillEmailAndPassword(user.Email, user.Password)
                .LoginButtonClick();
            Assert.True(myAccountPage.IsThisPage(), "This is not authentication page!");

            var wishlistPage = myAccountPage.MyWishlistButtonClick();
            Assert.True(wishlistPage.IsThisPage(), "This is not wishlist page");

            wishlistPage.CleanWishList();
            Assert.True(wishlistPage.IsWishlistEmpty(), "Wishlist is not empty");
            Assert.True(wishlistPage.IsThisPage(), "This is not wishlist page");

            //Создание своего Wishlist
            wishlistPage.FillNameWishlistField().SaveWishlistButtonClick();
            Assert.AreEqual(wishlistPage.GetCountWishlist(), 1);
            //

            var womanTabPage = wishlistPage.MenuHeader.WomenTabClick();
            Assert.True(womanTabPage.IsThisPage(), "This is not woman tab page");

            var productPage = womanTabPage.ChooseProduct();
            Assert.True(productPage.IsThisPage(), "This is not product page");

            productPage.AddToWishlistButtonClick();
            Assert.True(productPage.IsThisPage(), "This is not product page");

            myAccountPage = productPage.MenuHeader.AccountClick();
            Assert.True(myAccountPage.IsThisPage(), "This is not authentication page!");

            wishlistPage = myAccountPage.MyWishlistButtonClick();
            Assert.True(wishlistPage.IsThisPage(), "This is not wishlist page");

            Assert.AreEqual(1, wishlistPage.QuantityProductFromUserWishlist());
        }
    }
}
