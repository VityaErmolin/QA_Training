using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class WaiterTests
    {
        private static string URL = "https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html";
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = URL;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void GetRandomUserTest()
        {
            driver.FindElement(By.Id("save")).Click();
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

            var elem = waiter.Until(ExpectedConditions
                .ElementIsVisible(By.CssSelector("#loading>img")));

            Assert.True(elem.Displayed, "Element should be displayed");
        }

        [Test]
        public void GetRandomUserTest2()
        {
            driver.FindElement(By.Id("save")).Click();
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

            var elementBeDisplayed = waiter.Until(condition =>
            {
                try
                {
                    return driver
                        .FindElement(By.CssSelector("#loading>img"))
                        .Displayed;
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

            Assert.True(elementBeDisplayed, "The element is not displayed");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
