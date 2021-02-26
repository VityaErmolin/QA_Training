using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task70.Pages
{
    internal class LoginPage : Page
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "login")]
        internal IWebElement LoginInput;

        [FindsBy(How = How.Name, Using = "password")]
        internal IWebElement PasswordInput;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'auth__enter')]")]
        internal IWebElement LoginAccountButton;

        internal LoginPage Open()
        {
            _driver.FindElement(By.ClassName("enter")).Click();
            return this;
        }

        public void Logout()
        {
            _driver.FindElement(By.ClassName("uname")).Click();
            _driver.FindElement(By.XPath("//a[contains(@class,'auth__reg')]")).Click();
        }

    public bool IsThisPage()
        {
            return _driver.Title.Equals("Белорусский портал TUT.BY. Новости Беларуси и мира");
        }
    }
}
