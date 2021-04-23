using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task150.Pages
{
    internal class CartPage : Page
    {
        [FindsBy(How = How.ClassName, Using = "icon-trash")]
        private IList<IWebElement> ProductDeleteButtonList;

        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool IsThisPage()
        {
            var titleCart = By.Id("cart_title");
            return _driver.FindElement(titleCart).Displayed;
        }

        public CartPage CleanCart()
        {
            if (!IsEmpty())
            {
                foreach (var deleteProductButton in ProductDeleteButtonList)
                {
                    deleteProductButton.Click();
                }
            }

            return this;
        }

        public int GetCountProducts()
        {
            return ProductDeleteButtonList.Count;
        }

        public bool IsEmpty()
        {
            return ProductDeleteButtonList.Count == 0;
        }
    }
}