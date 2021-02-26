using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Task70.Model;
using Task70.Pages;

namespace Task70.App
{
    public class Application
    {
        private readonly IWebDriver _driver;

        private readonly HomePage homePage;
        private readonly LoginPage loginPage;

        public Application()
        {
            _driver = new ChromeDriver();
            homePage = new HomePage(_driver);
            loginPage = new LoginPage(_driver);
        }

        public void LoginUser(User user)
        {
            homePage.Open();
            loginPage.Open();
            loginPage.LoginInput.SendKeys(user.Login);
            loginPage.PasswordInput.SendKeys(user.Password);
            loginPage.LoginAccountButton.Click();
        }

        public void LogoutUser()
        {
            loginPage.Logout();
        }

        public bool LoggedIn()
        {
            return homePage.IsThisPage() && WaitElementDisplayed("uname");
        }

        public bool LoggedOut()
        {
            return homePage.IsThisPage() && WaitElementDisplayed("enter");
        }

        public void Quit()
        {
            _driver.Quit();
        }

        private bool WaitElementDisplayed(string className)
        {
            var waiter = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));

            var element = waiter.Until(condition =>
            {
                try
                {
                    return _driver.FindElement(By.ClassName(className)).Displayed;
                }
                catch (InvalidElementStateException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            return element;
        }
    }
}