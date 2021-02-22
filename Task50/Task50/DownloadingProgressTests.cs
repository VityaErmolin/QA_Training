using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class DownloadingProgressTests
    {
        private static string URL = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
        private static IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = URL;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void ProgressBarForDownloadTest()
        {
            driver.FindElement(By.Id("cricle-btn")).Click();
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = waiter.Until(condition =>
            {
                try
                {
                    var progress = driver.FindElement(By.ClassName("percenttext")).Text;
                    progress = progress.Replace("%", "");
                    var result = int.TryParse(progress, out int value)
                        ? value
                        : throw new ArgumentException("Cannot convert from string to integer");
                    return result >= 50;
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

            if (element)
            {
                driver.Navigate().Refresh();
            }

            var elementText0 = driver.FindElement(By.ClassName("percenttext")).Text;
            Assert.AreEqual(elementText0, "0%");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
