using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task70.Pages
{
    internal class Page
    {
        protected IWebDriver _driver;
        protected WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
    }
}
