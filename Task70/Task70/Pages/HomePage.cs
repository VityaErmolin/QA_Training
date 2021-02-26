using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task70.Pages
{
    internal class HomePage:Page
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        internal HomePage Open()
        {
            _driver.Url = "https://www.tut.by/";
            return this;
        }

        public bool IsThisPage()
        {
            return _driver.Title.Equals("Белорусский портал TUT.BY. Новости Беларуси и мира");
        }

    }
}
