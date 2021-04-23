using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using Task150.HelperPage;

namespace Task150.Pages
{
    internal class WomenTabPage : Page
    {
        
        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'product_list')]/li")]
        private IList<IWebElement> ItemsElements { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".wishlist>a")]
        private IWebElement AddToWishlist { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        private IWebElement CloseFancybox { get; set; }

        public WomenTabPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool IsThisPage()
        {
            return _driver.Title.Equals("Women - My Store");
        }

        public WomenTabPage MoveToElement(int number)
        {
            var action = new Actions(_driver);
            action.MoveToElement(ItemsElements[number - 1]).Perform();
            return this;
        }

        public WomenTabPage AddToWishlisClick()
        {
            AddToWishlist.Click();
            return this;
        }

        public WomenTabPage AddProductToCart(int amountItem)
        {
            var action = new Actions(_driver);
            for (var i = 0; i < amountItem && IsThisPage(); i++)
            {
                action.MoveToElement(ItemsElements[i]).Perform();
                AddItem(i + 1);
            }

            return this;
        }

        public WomenTabPage CloseFancyboxClick()
        {
            CloseFancybox.Click();
            return this;
        }

        private void AddItem(int number)
        {
            _driver.FindElement(By.XPath(
                    $"//li[{number}]/div/div/div[@class='button-container']/a[contains(@class,'ajax_add_to_cart_button')]"))
                .Click();
            if (_driver.WaiterByElementIsDisplay(By.Id("layer_cart"), 5000))
            {
                _driver.FindElement(By.XPath("//span[contains(@class, 'continue')]")).Click();
            }
        }
    }
}