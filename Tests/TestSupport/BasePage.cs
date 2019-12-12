using System;
using OpenQA.Selenium;

namespace SFA.TL.ResultsAndCertification.Automation.Tests.Tests.TestSupport
{
    public class BasePage
    {
        private  readonly IWebDriver webDriver;

        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        private IWebElement pageHeading
        {
            get
            {
                return this.webDriver.FindElement(By.CssSelector("h1"));
            }
        }

        protected String GetPageHeading()
        {
            return pageHeading.Text;
        }
    }
}