using GoogleDriveVerification.Google.Pages.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleDriveVerification.Google.Pages
{
    class LoginPasswordPage
    {
        private const String LOGIN_PASSWORD_LOCATOR = "//input[@name='password']";
        private const String LOGIN_BUTTON_LOCATOR_ID = "passwordNext";


        private static IWebDriver driver;

        private static IWebElement loginPasswordElement;
        private static IWebElement loginPasswordNextButton;

        private LoginPasswordPage()
        {
        }

        public static LoginPasswordPage Create(IWebDriver driverArg)
        {
            driver = driverArg;
            By passwordLocator = By.XPath(LOGIN_PASSWORD_LOCATOR);
            loginPasswordElement = WaitForElement.Wait(driver, passwordLocator);
            loginPasswordNextButton = driver.FindElement(By.Id(LOGIN_BUTTON_LOCATOR_ID));
            return new LoginPasswordPage();
        }

        public void setPassword(String password)
        {
            loginPasswordElement.SendKeys("" + password);
        }

        public HomePage SubmitPassword()
        {
            loginPasswordNextButton.Click();
            
            HomePage homePage = HomePage.Create(driver);
            return homePage;
        }

    }
}
