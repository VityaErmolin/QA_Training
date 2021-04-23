using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Task150.HelperPage;

namespace Task150.Pages
{
    internal class ProductPage : Page
    {
        [FindsBy(How = How.Id, Using = "wishlist_button")]
        private IWebElement AddToWishlistButton;

        [FindsBy(How = How.XPath, Using = "//h1[@itemprop='name']")]
        private IWebElement ProductTitle;


        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool IsThisPage()
        {
            var productTitle = By.XPath("//h1[@itemprop='name']");
            return _driver.WaiterByElementIsDisplay(productTitle)
                   && _driver.FindElement(productTitle).Displayed;
        }

        public ProductPage AddToWishlistButtonClick()
        {
            AddToWishlistButton.Click();

            var infoWindowsButton = By.CssSelector(".fancybox-skin>a");
            if (_driver.WaiterByElementIsDisplay(infoWindowsButton))
            {
                _driver.FindElement(infoWindowsButton).Click();
            }

            return this;
        }
    }
}