using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using Task150.Model;
using Task150.Pages;

namespace Task150.Tests
{
    internal class AddProductToAutoCreatedWishlistTest : TestBase
    {
        [AllureSubSuite("CanAddProductToAutoCreatedWishlistTest")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/VityaErmolin/QA_Training")]
        [AllureTest("This test create and add product to auto-Wishlist")]
        [AllureOwner("Viktor Ermolin")]
        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsersWithCustomEmail")]
        public void CanAddProductToAutoCreatedWishlistTest(User user)
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

            var womanTabPage = wishlistPage.MenuHeader.WomenTabClick();
            Assert.True(womanTabPage.IsThisPage(), "This is not woman tab page");

            myAccountPage = womanTabPage.MoveToElement(1)
               .AddToWishlisClick()
               .CloseFancyboxClick()
               .MenuHeader.AccountClick();
           Assert.True(myAccountPage.IsThisPage(), "This is not authentication page!");

           wishlistPage = myAccountPage.MyWishlistButtonClick();
           Assert.True(wishlistPage.IsThisPage(), "This is not wishlist page");

            Assert.AreEqual(1, wishlistPage.GetCountWishlist());
        }
    }
}