using System;
using Allure.Commons;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Task110
{
    public class Tests : AllureReport
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
        [AllureSubSuite("Logout")]
        [AllureSeverity(SeverityLevel.Normal)]
        [AllureLink("TUT.BY", "https://www.tut.by/")]
        [AllureTest("This test for displayed")]
        [AllureOwner("Displayed")]
        public void Test1()
        {
            var t = _driver.FindElement(By.ClassName("enter"));
            Assert.True(t.Displayed);
        }

        [TearDown]
        public void Close()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile("Screenshot" + DateTime.Now.ToFileTime() + ".png");
            }
            _driver.Quit();
        }
    }
}