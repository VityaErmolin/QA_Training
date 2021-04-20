using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Task150.HelperPage;

namespace Task150.Pages
{
    internal class MyAccountPage : Page
    {
        [FindsBy(How = How.CssSelector, Using = ".lnk_wishlist > a")]
        private IWebElement MyWishlistButton;

        public  MyAccountPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MyWishlistPage MyWishlistButtonClick()
        {
            MyWishlistButton.Click();
            return new MyWishlistPage(_driver);
        }

        public bool IsThisPage()
        {
            return _driver.WaiterByElementIsDisplay(By.CssSelector(".account>span"))
            &&_driver.Title.Equals("My account - My Store");
        }
    }
}