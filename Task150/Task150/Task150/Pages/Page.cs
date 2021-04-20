using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task150.HelperPage;

namespace Task150.Pages
{
    internal class Page
    {
        protected IWebDriver _driver;
        protected WebDriverWait wait;

        public MenuHeader MenuHeader { get; }

        public Page(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            MenuHeader = new MenuHeader(_driver);
        }

    }
}
