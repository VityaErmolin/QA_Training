using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using Task150.HelperPage;

namespace Task150.Pages
{
    internal class WomenTabPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'button lnk_view')]")]
        private IWebElement MoreButton;

        public WomenTabPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool IsThisPage()
        {
            return _driver.Title.Equals("Women - My Store");
        }

        public ProductPage ChooseProduct()
        {
            ActionMouseToProduct(1);
            MoreButton.Click();
            return new ProductPage(_driver);
        }

        public WomenTabPage AddedThreeProductToCart()
        {
            for (var i = 1; i <= 3 && IsThisPage(); i++)
            {
                ActionMouseToProduct(i);
                var byAddToCartButton = "//a[contains(@class, 'ajax_add_to_cart_button')]";

                if (_driver.WaiterByElementIsDisplay(By.XPath(byAddToCartButton)))
                {
                    var byaddToCartButton = By.XPath(GetProductStringXpathByNumber(i) + byAddToCartButton);
                    if (_driver.WaiterByElementIsDisplay(byaddToCartButton))
                    {
                        _driver.FindElement(byaddToCartButton).Click();
                    }

                }

                // MODULE Block cart 
                if (_driver.WaiterByElementIsDisplay(By.Id("layer_cart_product_title")))
                {
                    _driver.FindElement(By.ClassName("cross")).Click();
                }
            }

            return this;
        }

        private string GetProductStringXpathByNumber(int number)
        {
            return $"//ul[contains(@class, 'product_list')]/li[{number}]";
        }

        private void ActionMouseToProduct(int number)
        {
            var action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(By.XPath(GetProductStringXpathByNumber(number))));
        }
    }
}