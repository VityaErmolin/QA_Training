using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task50
{
    public class AlertsTests
    {
        private static string URL = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        private IWebDriver driver;
        
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = URL;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 
        }

        [Test]
        public void JavaScriptAlertBoxClickedOKTest()
        {
            driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']")).Click();
            var alert = driver.SwitchTo().Alert();
            Thread.Sleep(3000);
            var alertText = alert.Text;
            alert.Dismiss();
            Assert.AreEqual(alertText, "I am an alert box!", "The result is not the same as expected");
        }

        [Test]
        public void JavaScriptConfirmBoxClickedYesTest()
        {
            driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']")).Click();
            var alert = driver.SwitchTo().Alert();
            alert.Accept();

            var text = driver.FindElement(By.Id("confirm-demo")).Text;

            Assert.AreEqual(text, "You pressed OK!", "The result is not the same as expected!");
        }

        [Test]
        public void JavaScriptConfirmBoxClickedNoTest()
        {
            driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']")).Click();
            var alert = driver.SwitchTo().Alert();
            alert.Dismiss();

            var text = driver.FindElement(By.Id("confirm-demo")).Text;

            Assert.AreEqual(text, "You pressed Cancel!", "The result is not the same as expected");
        }

        [Test]
        public void JavaScriptAlertBoxWithInputTextClickedOkTest()
        {
            driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']")).Click();
            var alert = driver.SwitchTo().Alert();
            var inputText = "Viktor";
            alert.SendKeys(inputText);
            alert.Accept();
            var expectedText = "You have entered '" + inputText + "' !";
            var actualText =driver.FindElement(By.Id("prompt-demo")).Text;
            Assert.AreEqual(expectedText, actualText, "The entered text does not match the expected text!");
        }

        [Test]
        public void JavaScriptAlertBoxWithInputTextClickedNoTest()
        {
            driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']")).Click();
            var alert = driver.SwitchTo().Alert();
            var inputText = "Viktor";
            alert.SendKeys(inputText);
            alert.Dismiss();
            var actualText = driver.FindElement(By.Id("prompt-demo")).Text;
            Assert.AreEqual(string.Empty, actualText, "The result should be empty!");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}