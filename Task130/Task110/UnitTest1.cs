using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Task110
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new RemoteWebDriver(new Uri("http://10.10.104.62:4444/wd/hub"), new ChromeOptions());
            _driver.Url = "https://www.tut.by/";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Test1()
        {
            var t = _driver.FindElement(By.ClassName("enter"));
            Assert.True(!t.Displayed);
        }

        [TearDown]
        public void Close()
        {

            _driver.Quit();
        }
    }
}