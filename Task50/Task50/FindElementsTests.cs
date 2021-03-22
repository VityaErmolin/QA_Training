using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class FindElementsTests
    {
        private static string TUT_BY_URL = "https://www.tut.by/";
        private static string USERNAME1 = "seleniumtests@tut.by";
        private static string USERNAME2 = "seleniumtests2@tut.by";
        private static string PASSWORD = "123456789zxcvbn";
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(15);
            driver.Url = TUT_BY_URL;
        }


        [Test]
        public void Test1()
        {
            By buttonEnter = By.XPath("//a[@class = 'enter']");
            driver.FindElement(buttonEnter).Click();

            By inputLogin = By.XPath("//input[@name ='login']");
            driver.FindElement(inputLogin).SendKeys(USERNAME1);

            By inputPassword = By.XPath("//input[@name ='password']");
            driver.FindElement(inputPassword).SendKeys(PASSWORD);

            Thread.Sleep(1000);

            By clickEnter = By.XPath("//input[@class = 'button m-green auth__enter']");
            driver.FindElement(clickEnter).Click();
            

            By userName = By.XPath("//span[@class = 'uname']");
            Assert.True(driver.FindElement(userName).Displayed, "Login name is not displayed! Authorization failed");

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            By buttonEnter = By.ClassName("enter");
            driver.FindElement(buttonEnter).Click();

            By inputLogin = By.Name("login");
            driver.FindElement(inputLogin).SendKeys(USERNAME2);

            By inputPassword = By.Name("password");
            driver.FindElement(inputPassword).SendKeys(PASSWORD);

            By clickEnter = By.CssSelector("input[class='button m-green auth__enter']");
            driver.FindElement(clickEnter).Click();

            var waiter = new WebDriverWait(driver, TimeSpan.FromMilliseconds(0));
            var isUsernameDisplayed = waiter.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed =
                        driver.FindElement(By.ClassName("uname"));
                    return elementToBeDisplayed.Displayed;
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
            
            Assert.True(isUsernameDisplayed, "Login name is not displayed!");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}