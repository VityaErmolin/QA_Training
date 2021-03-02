using OpenQA.Selenium;

namespace Task70.Pages
{
    internal class HomePage : Page
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }


        public bool IsThisPage()
        {
            return _driver.Title.Equals("Белорусский портал TUT.BY. Новости Беларуси и мира");
        }
    }
}