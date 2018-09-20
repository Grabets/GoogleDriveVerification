using GoogleDriveVerification.Google.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace GoogleDriveVerification.Google.Tests.FeatureSteps
{
    [Binding]
    public class LoginWithRightCredentialsSteps
    {
        private const String START_PAGE_URL = "https://www.google.com.ua/";

        private IWebDriver driver;
        StartPage startPage;
        HomePage homePage;

        [BeforeFeature]
        public void IncognitoWebDriverCreation()
        {
            driver = CreateIncognitoGoogleChromeWebDriver.Create();
        }

        [AfterFeature]
        public void DriverDispose()
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
            ScenarioContext.Current.Pending();
        }
        
        [When(@"in opened login page user enter (.*)")]
        public void WhenInOpenedLoginPageUserEnter(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"click next")]
        public void WhenClickNext()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"in opened password page user enter (.*)")]
        public void WhenInOpenedPasswordPageUserEnter(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        #endregion

        #region Then
        [Then(@"Home page should be created")]
        public void ThenHomePageShouldBeCreated()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion
    }
}
