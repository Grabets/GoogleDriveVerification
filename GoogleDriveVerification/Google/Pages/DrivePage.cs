using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Support.UI;

namespace GoogleDriveVerification.Google.Pages
{
    class DrivePage
    {
        
        private const String CREATE_BUTTON_LOCATOR = "//button[@guidedhelpid][1]";
        private const String PROFILE_BUTTON_LOCATOR = "//a[@class='gb_b gb_eb gb_R']";

        private static IWebDriver driver;
        private static IWebElement createButton;
        private static IWebElement profileButton;

        private DrivePage()
        {
        }

        public static DrivePage Init(IWebDriver driverArg)
        {
            driver = driverArg;
            createButton = driver.FindElement(By.XPath(CREATE_BUTTON_LOCATOR));
            profileButton = driver.FindElement(By.XPath(PROFILE_BUTTON_LOCATOR));
            return new DrivePage();
        }

        public void LogOut()
        {
            profileButton.Click();
            By logOutButtonLocator = By.Id("gb_71");
            MyWait(logOutButtonLocator).Click();

        }

        public void UploadDocument()
        {
            createButton.Click();
            Thread.Sleep(1000);

            Actions actions = new Actions(driver);
            actions.SendKeys(OpenQA.Selenium.Keys.Down).SendKeys(OpenQA.Selenium.Keys.Enter).Build().Perform();

            string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"TestData\testfile.txt");

            Thread.Sleep(1000);
            SendKeys.SendWait(path);
            SendKeys.SendWait(@"{ENTER}");
            WaitForDownloadingFile();
        }

        private void WaitForDownloadingFile()
        {
            IWebElement downloadElement = driver.FindElement(By.ClassName("le-Ba"));
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

            By deleteButtonLocator = By.XPath("//div[@class='h-sb-Ic h-R-d a-c-d'][4]");
            MyWait(deleteButtonLocator);
            driver.FindElement(deleteButtonLocator).Click();

            By deleteMessageLocator = By.XPath("//span[@class='a-la-B-x']");
            MyWait(deleteMessageLocator);
        }

        private IWebElement findFileByName(String fileName)
        {
            string templateXPathLocator = "//div[@aria-label='{0}']//span[text()='{0}']";
            string fileNameXPathLocator = String.Format(templateXPathLocator, fileName);
            try
            {
                IWebElement element = driver.FindElement(By.XPath(fileNameXPathLocator));
                return element;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private IWebElement MyWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            return wait.Until(d => d.FindElement(locator));
        }

    }
}
