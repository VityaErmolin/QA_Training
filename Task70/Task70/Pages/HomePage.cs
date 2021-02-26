using OpenQA.Selenium;

namespace Task70.Pages
{
    internal class HomePage : Page
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