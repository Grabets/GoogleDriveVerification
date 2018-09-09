using GoogleDriveVerification.Google.Pages.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDriveVerification.Google.Pages
{
    class StartPage
    {
        private const String LOGIN_BUTTON_LOCATOR_ID = "gb_70";

        private static IWebDriver driver;
        private static IWebElement loginButton;

        private StartPage()
        {

        }

        public static StartPage Create(IWebDriver driverArg)
        {
            driver = driverArg;
            By loginButtonLocator = By.Id(LOGIN_BUTTON_LOCATOR_ID);
            loginButton = WaitForElement.Wait(driver, loginButtonLocator);
            return new StartPage();
        }


        public LoginNamePage loginButtonClick()
        {
            loginButton.Click();
            LoginNamePage loginNamePage = LoginNamePage.Create(driver);
            return loginNamePage;
        }

    }
}
