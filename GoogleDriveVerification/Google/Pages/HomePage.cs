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
    class HomePage
    {
        private const String LOGIN_BUTTON_LOCATOR_ID = "gb_70";
        private const String POP_UP_BUTTON_LOCATOR = "//a[@class='gb_b gb_ec']";
        private const String DRIVE_BUTTON_ID_LOCATOR = "ogbkddg:7";


        private static IWebDriver driver;
        private static IWebElement popUpButton;


        private HomePage()
        {

        }

        public static HomePage Init(IWebDriver driverArg)
        {
            driver = driverArg;
            Thread.Sleep(2000);
            By popUpButtonLocator = By.XPath(POP_UP_BUTTON_LOCATOR);
            popUpButton = driver.FindElement(popUpButtonLocator);
            return new HomePage();
        }


        public DrivePage openDrivePage()
        {
            popUpButton.Click();
            By driveButtonLocator = By.Id(DRIVE_BUTTON_ID_LOCATOR);
            MyWait(driveButtonLocator);
            driver.FindElement(driveButtonLocator).Click();
            DrivePage drivePage = DrivePage.Init(driver);
            return drivePage;

        }

        private static IWebElement MyWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            return wait.Until(d => d.FindElement(locator));
        }

    }
}
