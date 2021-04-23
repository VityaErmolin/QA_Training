﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task150.HelperPage
{
    public static class Waiter
    {
        public static bool WaiterByElementIsDisplay(this IWebDriver _driver, By byElement, int timeMillisecond=15000)
        {
           var waiter = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(timeMillisecond));

            var element = waiter.Until(condition =>
            {
                try
                {
                    return _driver.FindElement(byElement).Displayed;
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

            return element;
        }

        public static bool WaiterByElementIsNotDisplay(this IWebDriver _driver, By byElement, int timeMillisecond = 10000)
        {
            var waiter = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(timeMillisecond));

            var element = waiter.Until(condition =>
            {
                try
                {
                    var elementToBeNotDisplay = _driver.FindElements(byElement);
                    return elementToBeNotDisplay.Count == 0;
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

            return element;
        }
    }
}