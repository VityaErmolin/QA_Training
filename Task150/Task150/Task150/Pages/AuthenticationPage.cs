﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task150.Pages
{
    internal class AuthenticationPage : Page
    {
        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        private IWebElement CreateAnAccountButton;

        [FindsBy(How = How.Id, Using = "email_create")]
        private IWebElement EmailCreateField;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement EmailField;

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement PasswordField;

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement SignInButton;

        public AuthenticationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public AuthenticationPage Open()
        {
            _driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
            return new AuthenticationPage(_driver);
        }

        public AuthenticationPage FillEmailFieldForRegister(string email)
        {
            EmailCreateField.SendKeys(email);
            return this;
        }

        public AccountCreationPage CreateAccountButtonClick()
        {
            CreateAnAccountButton.Click();
            return new AccountCreationPage(_driver);
        }

        public AuthenticationPage FillEmailAndPassword(string email, string password)
        {
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            return this;
        }

        public MyAccountPage LoginButtonClick()
        {
            SignInButton.Click();
            return new MyAccountPage(_driver);
        }

        public bool IsThisPage()
        {
            return _driver.Title.Equals("Login - My Store");
        }
    }
}