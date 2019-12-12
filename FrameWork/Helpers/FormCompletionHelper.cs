using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SFA.TL.ResultsAndCertification.Automation.Tests.Framework.Helpers
{
    public class FormCompletionHelper : PageInteractionHelper
    {
        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void ClickElement(By locator)
        {
            WebDriver.FindElement(locator).Click();
        }

        public static void ClearText(By locator)
        {
            WebDriver.FindElement(locator).Clear();
        }

        public static void EnterText(IWebElement element, String text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void EnterText(By locator, String text)
        {
            WebDriver.FindElement(locator).Clear();
            WebDriver.FindElement(locator).SendKeys(text);
        }

        public static void EnterText(IWebElement element, int value)
        {
            if (element != null)
            {
                element.Clear();
                element.SendKeys(value.ToString());
            }
        }

        public static void PressTabKey()
        {
            IWebElement element = WebDriver.FindElement(By.TagName("body"));
            element.SendKeys(Keys.Tab);
        }

        public static void SelectFromDropDownByValue(IWebElement element, String value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public static void SelectFromDropDownByValue(By locator, String value)
        {
            IWebElement element = WebDriver.FindElement(locator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public static void SelectFromDropDownByText(By locator, String value)
        {
            IWebElement element = WebDriver.FindElement(locator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(value);
        }

        public static void SelectFromDropDownByText(IWebElement element, String text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public static void SelectCheckBox(IWebElement element)
        {
            if (element != null && (element.Displayed && !element.Selected))
            {
                element.Click();
            }
        }

        public static void SelectCheckBox(By locator)
        {
            IWebElement element = WebDriver.FindElement(locator);
            SelectCheckBox(element);
        }

        public static void SelectRadioOptionByForAttribute(By locator, String forAttribute)
        {
            IList<IWebElement> radios = WebDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }
    }
}