using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class MultiselectTests
    {
        private static string URL = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = URL;
        }

        [Test]
        public void SelectListDemo()
        {
            var element = driver.FindElement(By.Id("select-demo"));
            var select = new SelectElement(element);
            Assert.False(select.IsMultiple);
            Assert.AreEqual(8, select.Options.Count);
            select.SelectByValue("Monday");
            Assert.AreEqual("Monday", select.SelectedOption.Text);
            Thread.Sleep(1500);
        }

        [Test]
        public void MultiSelectListDemo()
        {
            var element = driver.FindElement(By.Id("multi-select"));
            var select = new SelectElement(element);
            Assert.True(select.IsMultiple);
            Assert.AreEqual(8, select.Options.Count);

            select.SelectByValue("California");
            select.SelectByValue("New York");
            select.SelectByValue("Washington");

            var expectedOptions = new List<string> 
                { 
                    "California",
                    "New York", 
                    "Washington"
                };

            var actualOptions =new List<string>();
            foreach (var option in select.AllSelectedOptions)
            {
                actualOptions.Add(option.Text);
            } 
            
            Assert.AreEqual(expectedOptions, actualOptions);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
