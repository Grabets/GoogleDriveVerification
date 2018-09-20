using GoogleDriveVerification.Google.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace GoogleDriveVerification.Google.Tests.FeatureSteps
{
    [Binding]
    public class LoginWithRightCredentialsSteps
    {
        private const String START_PAGE_URL = "https://www.google.com.ua/";
        private const String HOME_PAGE_TITLE = "Google";

        private static IWebDriver driver;
        StartPage startPage;
        LoginNamePage nameLoginPage;
        LoginPasswordPage passwordLoginPage;
        HomePage homePage;

        [BeforeFeature]
        public static void IncognitoWebDriverCreation()
        {
            driver = CreateIncognitoGoogleChromeWebDriver.Create();
        }

        [AfterFeature]
        public static void DriverDispose()
        {
            driver.Dispose();
        }

        #region When
        [When(@"I open google start page")]
        public void WhenIOpenGoogleStartPage()
        {
            driver.Navigate().GoToUrl(START_PAGE_URL);
            startPage = StartPage.Create(driver);
        }
        
        [When(@"push login button")]
        public void WhenPushLoginButton()
        {
            nameLoginPage = startPage.loginButtonClick();
        }
        
        [When(@"in opened login page user enter (.*)")]
        public void WhenInOpenedLoginPageUserEnter(string userName)
        {
            nameLoginPage.setEmailAddress(userName);
        }
        
        [When(@"click proceed to password button")]
        public void WhenClickProccedToPasswordButton()
        {
            passwordLoginPage = nameLoginPage.ProceedToPassword();
        }
        
        [When(@"in opened password page user enter (.*)")]
        public void WhenInOpenedPasswordPageUserEnter(string password)
        {
            passwordLoginPage.setPassword(password);
        }

        [When(@"click submit button")]
        public void WhenClickSubmitButton()
        {
            homePage = passwordLoginPage.SubmitPassword();
        }
        #endregion

        #region Then
        [Then(@"Home page should be created")]
        public void ThenHomePageShouldBeCreated()
        {

            String title = driver.Title;
            Assert.AreEqual(HOME_PAGE_TITLE,title, "Incorrect home page title");
        }
        #endregion
    }
}
