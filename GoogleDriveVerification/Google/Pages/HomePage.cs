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
    class HomePage
    {
        private const String POP_UP_BUTTON_LOCATOR = "//a[@class='gb_b gb_ec']";
        private const String DRIVE_BUTTON_ID_LOCATOR = "ogbkddg:7";


        private static IWebDriver driver;
        private static IWebElement popUpButton;


        private HomePage()
        {

        }

        public static HomePage Create(IWebDriver driverArg)
        {
            driver = driverArg;
            Thread.Sleep(2000);
            By popUpButtonLocator = By.XPath(POP_UP_BUTTON_LOCATOR);
            popUpButton = driver.FindElement(popUpButtonLocator);
            return new HomePage();
        }


        public DrivePage OpenDrivePage()
        {
            while (popUpButton.GetAttribute("aria-expanded").Equals("false"))
            {
                popUpButton.Click();
            }
            
            By driveButtonLocator = By.Id(DRIVE_BUTTON_ID_LOCATOR);
            IWebElement openDriverPage = WaitForElement.Wait(driver, driveButtonLocator);
            openDriverPage.Click();
            DrivePage drivePage = DrivePage.Create(driver);
            return drivePage;

        }


    }
}
