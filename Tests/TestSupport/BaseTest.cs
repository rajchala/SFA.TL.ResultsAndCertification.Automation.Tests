using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Collections.Generic;
using SFA.TL.ResultsAndCertification.Automation.Tests.Framework.Helpers;

namespace SFA.TL.ResultsAndCertification.Automation.Tests.Tests.TestSupport
{
    [Binding]
    public class BaseTest
    {
        private static IWebDriver webDriver;

        [Before]
        public static void SetUp()
        {
            String browser = Configurator.GetConfiguratorInstance().GetBrowser();

            switch (browser)
            {
                case "firefox":
                    webDriver = new FirefoxDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(new List<string>()
                        {
                            "--no-sandbox",
                        });
                    webDriver = new ChromeDriver(chromeOptions);
                    break;

                case "ie":
                    webDriver = new InternetExplorerDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "edge":
                    webDriver = new EdgeDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "safari":
                    webDriver = new SafariDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "zapProxyChrome":
                    InitialiseZapProxyChrome();
                    break;

                default:
                    throw new Exception("Driver name - " + browser + "does not match OR this framework does not support the webDriver specified");
            }

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            webDriver.Manage().Cookies.DeleteAllCookies();
            string currentWindow = webDriver.CurrentWindowHandle;
            webDriver.SwitchTo().Window(currentWindow);
            webDriver.Navigate().GoToUrl(Configurator.GetConfiguratorInstance().GetBaseUrl());

            PageInteractionHelper.SetDriver(webDriver);
        }

        [After]
        public static void TearDown()
        {
            webDriver.Dispose();
           
        }
        private static void InitialiseZapProxyChrome()
        {
            const string proxyServer = "localhost:8080";
            var chromeOptions = new ChromeOptions();
            var proxy = new Proxy();
            proxy.HttpProxy = proxyServer;
            proxy.SslProxy = proxyServer;
            proxy.FtpProxy = proxyServer;
            chromeOptions.Proxy = proxy;

            webDriver = new ChromeDriver(chromeOptions);
        }
    }
}