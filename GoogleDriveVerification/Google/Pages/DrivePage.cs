using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using GoogleDriveVerification.Google.Pages.Core;

namespace GoogleDriveVerification.Google.Pages
{
    class DrivePage
    {
        
        private const String CREATE_BUTTON_LOCATOR = "//button[@guidedhelpid][1]";
        private const String PROFILE_BUTTON_LOCATOR = "//a[@class='gb_b gb_eb gb_R']";
        private const String LOG_OUT_BUTTON_ID_LOCATOR = "gb_71";
        private const String FILE_PATH_LOCATION = @"TestData\";
        private const String DOWNLOAD_ELEMENT_CLASS_LOCATOR = "le-Ba";
        private const String DELETE_BUTTON_XPATH_LOCATOR = "//div[@class='h-sb-Ic h-R-d a-c-d'][4]";
        private const String DELETE_MESSAGE_XPATH_LOCATOR = "//span[@class='a-la-B-x']";
        private const string FILE_BY_NAME_XPATH_LOCATOR_TEMPLATE = "//div[@aria-label='{0}']//span[text()='{0}']";

        private static IWebDriver driver;
        private static IWebElement createButton;
        private static IWebElement profileButton;
        private static IWebElement downloadElement;

        private DrivePage()
        {
        }

        public static DrivePage Create(IWebDriver driverArg)
        {
            driver = driverArg;
            createButton = driver.FindElement(By.XPath(CREATE_BUTTON_LOCATOR));
            profileButton = driver.FindElement(By.XPath(PROFILE_BUTTON_LOCATOR));
            return new DrivePage();
        }

        public void LogOut()
        {
            profileButton.Click();
            By logOutButtonLocator = By.Id(LOG_OUT_BUTTON_ID_LOCATOR);
            IWebElement logOutButton = WaitForElement.Wait(driver, logOutButtonLocator);
            logOutButton.Click();

        }

        public void UploadDocument(String fileName)
        {
            createButton.Click();
            Thread.Sleep(1000);

            Actions actions = new Actions(driver);
            actions.SendKeys(OpenQA.Selenium.Keys.Down).SendKeys(OpenQA.Selenium.Keys.Enter).Build().Perform();

            string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), FILE_PATH_LOCATION+fileName);

            Thread.Sleep(1000);
            SendKeys.SendWait(path);
            SendKeys.SendWait(@"{ENTER}");
            WaitForDownloadingFile();
        }

        private void WaitForDownloadingFile()
        {
            By downloadElementClassLocator = By.ClassName(DOWNLOAD_ELEMENT_CLASS_LOCATOR);
            downloadElement = driver.FindElement(downloadElementClassLocator);
            do
            {
                Thread.Sleep(3000);
            }
            while (!downloadElement.GetAttribute("style").Contains("display"));
        }

        public Boolean CheckFilePresence(String fileName)
        {
            if (findFileByName(fileName).Equals(null))
            {
                return false;
            }
            return true;
        }

        public void DeleteDocument(String fileName)
        {
            IWebElement element = findFileByName(fileName);
            element.Click();

            By deleteButtonLocator = By.XPath(DELETE_BUTTON_XPATH_LOCATOR);
            IWebElement deleteButtonElement = WaitForElement.Wait(driver, deleteButtonLocator);
            deleteButtonElement.Click();

            By deleteMessageLocator = By.XPath(DELETE_MESSAGE_XPATH_LOCATOR);
            IWebElement deleteMessageElement = WaitForElement.Wait(driver, deleteMessageLocator);
        }

        private IWebElement findFileByName(String fileName)
        {
            
            string fileNameXPathLocator = String.Format(FILE_BY_NAME_XPATH_LOCATOR_TEMPLATE, fileName);

            IWebElement element = null;
            try
            {
                element = driver.FindElement(By.XPath(fileNameXPathLocator));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }

            return element;

        }

       
    }
}
