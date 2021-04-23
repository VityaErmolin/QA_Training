using OpenQA.Selenium;

namespace Task150.Pages
{
    internal class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public MainPage Open()
        {
            _driver.Url = "http://automationpractice.com/index.php";
            return new MainPage(_driver);
        }

        public bool IsThisPage()
        {
            return _driver.Title.Equals("My Store");
        }
    }
}