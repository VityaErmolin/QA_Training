using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Task50.Helpers;

namespace Task50
{
    public class TableSortAndSearchTests
    {
        private const int AGE = 26;
        private const int SALARY = 150000;
        private static readonly string URL = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";
        private static IWebDriver driver;
        private IEnumerable<Employee> EMPLOYEES = new List<Employee>();

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = URL;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void GetFilteringEmployeesTest()
        {
            var selector = new SelectElement(driver.FindElement(By.XPath("//select[@name='example_length']")));
            Assert.False(selector.IsMultiple, "Selector cannot be multiple!");
            selector.SelectByValue("10");
            var expectedOption = "10";
            var actualOption = driver.FindElement(By.XPath("//option[@value='10']")).Text;
            Assert.AreEqual(expectedOption, actualOption, "The result cannot be equal less than or equal to 0!");

            //Count of page
            var countOfPage =
                driver.FindElements(By.CssSelector("#example_paginate span a")).Count;
            Assert.True(countOfPage > 0, "The count of pages must be greater than 0!"); 
            
            var employeesAll = GrabAllDataFromAllPages(countOfPage);

            EMPLOYEES = FilterEmployees(employeesAll);

            Assert.True(EMPLOYEES.Any(), "The result should not be empty");
        }

        private IEnumerable<Employee> GrabAllDataFromAllPages(int countOfPage)
        {
            var allData = new List<Employee>();

            for (var i = 1; i <= countOfPage; i++)
            {
                driver.FindElement(By.XPath("//a[@data-dt-idx='" + $"{i}" + "']")).Click();
                if (WaitUntilTablesNotEmpty())
                {
                    var items = driver.FindElements(By.CssSelector("#example tbody tr"));
                    var employeesFromPage = items.Select(ympl => new Employee
                    {
                        Name = ympl.FindElement(By.XPath("td[1]")).GetAttribute("data-search"),
                        Position = ympl.FindElement(By.XPath("td[2]")).Text,
                        Office = ympl.FindElement(By.XPath("td[3]")).Text,
                        Age = int.TryParse(ympl.FindElement(By.XPath("td[4]")).Text,
                            out var age)
                            ? age
                            : throw new ArgumentException("Cannot convert from string to integer."),

                        Salary = int.TryParse(ympl.FindElement(By.XPath("td[6]")).GetAttribute("data-order"),
                            out var salary)
                            ? salary
                            : throw new ArgumentException("Cannot convert from string to integer.")
                    });
                    allData.AddRange(employeesFromPage);
                }
            }

            Assert.True(allData.Any(), "The result should not be empty");
            return allData;
        }

        public bool WaitUntilTablesNotEmpty()
        {
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return waiter.Until(condition =>
            {
                try
                {
                    var items = driver.FindElements(By.CssSelector("#example tbody tr"));
                    Assert.True(items.Any(), "The result should not be empty");
                    return items.Any();
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
        }

        private IEnumerable<Employee> FilterEmployees(IEnumerable<Employee> allEmployees)=>allEmployees
                .Where(emp => emp.Age > AGE
                              && emp.Salary <= SALARY);

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}