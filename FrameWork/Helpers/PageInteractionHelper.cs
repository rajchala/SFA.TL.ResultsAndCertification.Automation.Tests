using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SFA.TL.ResultsAndCertification.Automation.Tests.Framework.Helpers
{
    public class PageInteractionHelper
    {
        protected static IWebDriver webDriver;
        private const int ImplicitWaitTimeInSeconds = 10;

        public static void SetDriver(IWebDriver webDriver)
        {
            PageInteractionHelper.webDriver = webDriver;
        }

        public static bool VerifyPageUrl(string actual, string expected)
        {
            if (actual == null || !expected.Contains(actual))
            {
                return true;
            }

            throw new Exception("Page URL verification failed:"
                + "\n Expected URL: " + expected
                + "\n Found URL: " + actual);
        }


        public static bool VerifyLinkIsPresent(By locator, string expected)
        {
            String actual = webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("The following link was not found: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public static bool VerifyPageHeading(string actual, string expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected page: " + expected
                + "\n Found page: " + actual);
        }

        public static bool VerifyPageHeading(By locator, string expected)
        {
            String actual = webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected page: " + expected
                + "\n Found page: " + actual);
        }

        public static bool VerifyPageHeading(string actual, string expected1, string expected2)
        {
            if (actual.Contains(expected1) || actual.Contains(expected2))
            {
                return true;
            }

            throw new Exception("Page verification failed: "
                + "\n Expected: " + expected1 + " or " + expected2 + " pages"
                + "\n Found: " + actual + " page");
        }

        public static bool VerifyText(string actual, string expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public static bool VerifyText(By locator, int expected)
        {
            String expectedText = Convert.ToString(expected);
            return VerifyText(locator, expectedText);
        }

        public static bool VerifyText(By locator, string expected)
        {
            string actual = webDriver.FindElement(locator).Text;
            return VerifyText(actual, expected);
        }

        public static bool VerifyValueAttributeOfAnElement(By locator, string expected)
        {
            string actual = webDriver.FindElement(locator).GetAttribute("value");
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Value verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public static void WaitForPageToLoad(int implicitWaitTime = ImplicitWaitTimeInSeconds)
        {
            var waitForDocumentReady = new WebDriverWait(webDriver, TimeSpan.FromSeconds(implicitWaitTime));
            waitForDocumentReady.Until((wdriver) => ((IJavaScriptExecutor) webDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void WaitForElementToBePresent(By locator)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(ImplicitWaitTimeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static void WaitForElementToBeDisplayed(By locator, int timeInSeconds = ImplicitWaitTimeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToBeClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(ImplicitWaitTimeInSeconds));
            //IWebElement element = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool IsElementPresent(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                webDriver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            finally
            {
                TurnOnImplicitWaits();
            }
        }

        public static bool IsElementDisplayed(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                return webDriver.FindElement(locator).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                TurnOnImplicitWaits();
            }
        }

        public static void FocusTheElement(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            new Actions(webDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public static void FocusTheElement(IWebElement element)
        {
            new Actions(webDriver).MoveToElement(element).Perform();
        }

        public static void UnFocusTheElement(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            new Actions(webDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public static void UnFocusTheElement(IWebElement element)
        {
            new Actions(webDriver).MoveToElement(element).Perform();
        }

        public static void TurnOffImplicitWaits()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        public static void TurnOnImplicitWaits()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeInSeconds);
        }

        public static String GetText(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            return webElement.Text;
        }

        public static String GetValueFromField(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            string value = webElement.GetAttribute("value");
            return value;
        }
    }
}