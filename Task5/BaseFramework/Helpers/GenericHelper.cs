using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BaseFramework.Libraries.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BaseFramework.Helpers
{
    public static class GenericHelper
    {

        public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element) => driver =>
        {
            try
            {
                return ElementIfVisible(element);
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };

        private static IWebElement ElementIfVisible(IWebElement element)
        {
            if (!IsElementVisible(element))
                return null;
            return element;
        }

        public static IWebElement WaitUntilElementIsVisible(this IWebDriver driver, IWebElement element, int timeOutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(ElementIsVisible(element)); //Wait finishes when return is a non-null value or 'true'
        }

        public static bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public static bool WaitUntilElementNotVisible(this IWebDriver driver, IWebElement element, int timeOutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(drv => !IsElementVisible(element));
        }

        public static bool HasClass(this IWebElement element, string className)
        {
            return element.GetAttribute("class").Split(' ').Contains(className);
        }

        public static bool WaitUntilUrlContains(this IWebDriver driver, string urlFragment, int timeOutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(ExpectedConditions.UrlContains(urlFragment));
        }

        public static bool WaitUntilElemValueEquals(this IWebDriver driver, IWebElement element, string value, int timeOutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(ExpectedConditions.TextToBePresentInElement(element, value));

        }

        public static IWebElement WaitUntilElementIsClickable(this IWebDriver driver, IWebElement element, int timeOutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void VerifyUrl(this WebDriver webDriver, string route)
        {
            StringAssert.AreEqualIgnoringCase(new Uri(route).LocalPath, new Uri(webDriver.GetCurrentUrl()).LocalPath, String.Format("Current page is not {0}", route));
        }

        public static Boolean ascendingCheck(List<int> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                if (data[i] > data[i + 1])
                {
                    return false;
                }
            }
            return true;
        }


    }
}
