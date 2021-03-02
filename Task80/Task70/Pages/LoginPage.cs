using System.IO;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace Task70.Pages
{
    internal class LoginPage : Page
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement LoginInput;

        [FindsBy(How = How.Name, Using = "password1")]
        private IWebElement PasswordInput;


        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'auth__enter')]")]
        private IWebElement Submit;

        [FindsBy(How = How.ClassName, Using = "uname")]
        private IWebElement UserMenu;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'auth__reg')]")]
        private IWebElement ButtonExit;



        internal LoginPage Open()
        {
            _driver.Url = "https://www.tut.by/";
            return this;
        }

        public LoginPage LoginAs(string username, string password) 
        {
            LoginInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            return this;
        }
        public LoginPage EnterClick()
        {
            _driver.FindElement(By.ClassName("enter")).Click();
            return this;
        }

        public HomePage SubmitClick()
        {
            Submit.Click();
            return new HomePage(_driver);
    }

        public HomePage Logout()
        {
            UserMenu.Click();
            ButtonExit.Click();
            return new HomePage(_driver);
        }
    }
}
