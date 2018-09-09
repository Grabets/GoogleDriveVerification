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

        public static StartPage Init(IWebDriver driverArg)
        {
            driver = driverArg;
            By loginButtonLocator = By.Id(LOGIN_BUTTON_LOCATOR_ID);
            loginButton = MyWait(loginButtonLocator);
            return new StartPage();
        }


        public LoginNamePage loginButtonClick()
        {
            loginButton.Click();
            LoginNamePage loginNamePage = LoginNamePage.Init(driver);
            return loginNamePage;
        }

        private static IWebElement MyWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            return wait.Until(d => d.FindElement(locator));
        }


    }
}
