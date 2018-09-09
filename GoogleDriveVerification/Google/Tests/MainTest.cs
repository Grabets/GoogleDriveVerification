using OpenQA.Selenium;
using NUnit.Framework;
using GoogleDriveVerification.Google.Pages;
using OpenQA.Selenium.Chrome;
using System;

namespace GoogleDriveVerification.Google.Tests
{
   
    public class MainTest
    {
        private const String HOME_PAGE_URL = "https://www.google.com.ua/";
        IWebDriver driver;
        HomePage homePage;
        DrivePage drivePage;


        [OneTimeSetUp]
        public void Init()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--incognito");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(HOME_PAGE_URL);
            homePage = HomePage.Init(driver);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            drivePage.LogOut();
            driver.Quit();
        }

        [Test]
        public void SimpleTest()
        {
            LoginWithDefaultUser();

            drivePage = homePage.openDrivePage();
            drivePage.UploadDocument();
            String fileName = "testfile.txt";
            bool isFilePresent = drivePage.CheckFilePresence(fileName);
            if (!isFilePresent)
            {
                Assert.Fail("The file wasn’t uploaded");
            }
            else
            {
                drivePage.DeleteDocument(fileName);
            }


        }

        private void LoginWithDefaultUser()
        {
            LoginNamePage loginPage = homePage.loginButtonClick();
            string emailAddress = "SeleniumWebDriverAutoTest";
            loginPage.LoginInput = emailAddress;
            LoginPasswordPage loginPasswordPage = loginPage.LoginNextClick();
            loginPasswordPage.PasswordInput = "zxcvbnm,./123";
            loginPasswordPage.LoginPasswordNextClick();
        }

    }
}
