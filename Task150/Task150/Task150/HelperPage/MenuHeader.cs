using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Task150.Pages;

namespace Task150.HelperPage
{
    internal class MenuHeader
    {
        protected IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@title='Women']")]
        private IWebElement WomenTab;

        [FindsBy(How = How.CssSelector, Using = ".shopping_cart > a")]
        private IWebElement CartButton;

        public MenuHeader(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        internal WomenTabPage WomenTabClick()
        {
            WomenTab.Click();
            return new WomenTabPage(_driver);
        }

        public MyAccountPage AccountClick()
        {
            var byAccountButton = By.ClassName("account");
            if(_driver.WaiterByElementIsDisplay(byAccountButton))
            {
                _driver.FindElement(byAccountButton).Click();
            }
            return new MyAccountPage(_driver);
        }

        public CartPage CartButtonClick()
        {
            CartButton.Click();
            return new CartPage(_driver);
        }

        public AuthenticationPage SingInClick()
        {
            _driver.FindElement(By.ClassName("login")).Click();
            return new AuthenticationPage(_driver);
        }
    }
}