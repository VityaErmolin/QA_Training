using System;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace Task150.Tests
{
    public class TestBase : AllureReport
    {
        protected IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
           
        }

        [TearDown]
        public void Stop()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                MakeScreenShot();
            }

            AllureLifecycle.Instance.RunStep("Closing driver", () =>
            {
                {
                    _driver?.Close();
                    _driver?.Dispose();
                }
            });
        }

        public void MakeScreenShot()
        {
            var nameScreenshot = "Screenshot_" + TestContext.CurrentContext.Test.MethodName + "_" +
                                 DateTime.Now.ToFileTime() + ".png";

                AllureLifecycle.Instance.AddAttachment(nameScreenshot, AllureLifecycle.AttachFormat.ImagePng,
                    _driver.TakeScreenshot().AsByteArray);
        }
    }
}