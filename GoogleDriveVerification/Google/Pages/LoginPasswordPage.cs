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

        public static LoginPasswordPage Init(IWebDriver driverArg)
        {
            driver = driverArg;
            Thread.Sleep(5000);
            /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath(LOGIN_PASSWORD_LOCATOR))));*/
            loginPasswordElement = driver.FindElement(By.XPath(LOGIN_PASSWORD_LOCATOR));
            loginPasswordNextButton = driver.FindElement(By.Id(LOGIN_BUTTON_LOCATOR_ID));
            return new LoginPasswordPage();
        }

        public String PasswordInput
        {
            set
            {
                loginPasswordElement.SendKeys("" + value);
            }
        }

        public HomePage LoginPasswordNextClick()
        {
            loginPasswordNextButton.Click();
            HomePage homePage = HomePage.Init(driver);
            return homePage;
        }

    }
}
