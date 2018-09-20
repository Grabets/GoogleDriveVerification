using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDriveVerification.Google.Tests
{
    public static class CreateIncognitoGoogleChromeWebDriver
    {
        private static IWebDriver driver;

        public static IWebDriver Create()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--incognito");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
