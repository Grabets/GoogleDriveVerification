using OpenQA.Selenium;
using NUnit.Framework;
using GoogleDriveVerification.Google.Pages;
using OpenQA.Selenium.Chrome;
using System;

namespace GoogleDriveVerification.Google.Tests
{
   
    public class DocumentOperationTest
    {
        private const String START_PAGE_URL = "https://www.google.com.ua/";
        private const String FILE_NAME = "testfile.txt";
        private const String EMAIL_ADDRESS = "SeleniumWebDriverAutoTest";
        private const String PASSWORD = "zxcvbnm,./123";


        IWebDriver driver;
        StartPage startPage;
        HomePage homePage;
        DrivePage drivePage;


        [OneTimeSetUp]
        public void Init()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--incognito");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(START_PAGE_URL);
            startPage = StartPage.Create(driver);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            drivePage.LogOut();
            driver.Quit();
        }

        [Test]
        public void MainTest()
        {
            LoginWithDefaultUser();

            drivePage = homePage.OpenDrivePage();
            drivePage.UploadDocument("testfile.txt");
            
            bool isFilePresent = drivePage.CheckFilePresence(FILE_NAME);
            if (!isFilePresent)
            {
                Assert.Fail("The file wasn’t uploaded");
            }
            else
            {
                drivePage.DeleteDocument(FILE_NAME);
            }


        }

        private void LoginWithDefaultUser()
        {
            LoginNamePage loginNamePage = startPage.loginButtonClick();
            loginNamePage.setEmailAddress(EMAIL_ADDRESS);

            LoginPasswordPage loginPasswordPage = loginNamePage.ProceedToPassword();
            loginPasswordPage.setPassword(PASSWORD);
            homePage = loginPasswordPage.SubmitPassword();
        }

    }
}
