using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task2Test
{
    public class Tests
    {
        private static string TUT_BY_URL = "https://www.tut.by/";
        private static string USERNAME = "seleniumtests@tut.by";
        private static string PASSWORD = "123456789zxcvbn";
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.FullScreen();
            driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Url = TUT_BY_URL;
        }

        [Test]
        public void Test1()
        {
            By buttonEnter = By.XPath("//a[@class = 'enter']");
            driver.FindElement(buttonEnter).Click();

            By inputLogin = By.XPath("//input[@name ='login']");
            driver.FindElement(inputLogin).SendKeys(USERNAME);

            By inputPassword = By.XPath("//input[@name ='password']");
            driver.FindElement(inputPassword).SendKeys(PASSWORD);

            By clickEnter = By.XPath("//input[@class = 'button m-green auth__enter']");
            driver.FindElement(clickEnter).Click();

            Thread.Sleep(3000);

            By userName = By.XPath("//span[@class = 'uname']");
            Assert.True(driver.FindElement(userName).Displayed, "Login name is not displayed! Authorization failed");
        }

        [Test]
        public void Test2()
        {
            By buttonEnter = By.ClassName("enter");
            driver.FindElement(buttonEnter).Click();

            By inputLogin = By.Name("login");
            driver.FindElement(inputLogin).SendKeys(USERNAME);

            By inputPassword = By.Name("password");
            driver.FindElement(inputPassword).SendKeys(PASSWORD);

            By clickEnter = By.CssSelector("input[class='button m-green auth__enter']");
            driver.FindElement(clickEnter).Click();

            By userName = By.ClassName("uname");
            Assert.True(driver.FindElement(userName).Displayed, "Login name is not displayed! Authorization failed");
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}