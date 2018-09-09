using OpenQA.Selenium;
using System;

namespace GoogleDriveVerification.Google.Pages
{
    class LoginNamePage
    {
        private const String LOGIN_INPUT_LOCATOR_ID = "identifierId";
        private const String LOGIN_BUTTON_LOCATOR_ID = "identifierNext";


        private static IWebDriver driver;

        private static IWebElement loginInputElement;
        private static IWebElement loginIdentifierNextButton;
      

        private LoginNamePage()
        {
        }

        public static LoginNamePage Init(IWebDriver driverArg)
        {
            driver = driverArg;
            loginInputElement = driver.FindElement(By.Id(LOGIN_INPUT_LOCATOR_ID));
            loginIdentifierNextButton = driver.FindElement(By.Id(LOGIN_BUTTON_LOCATOR_ID));
            return new LoginNamePage();
        }

        public String LoginInput
        {
            set
            {
                loginInputElement.SendKeys(""+value);
            }
        }

        public LoginPasswordPage LoginNextClick()
        {
            loginIdentifierNextButton.Click();
            LoginPasswordPage loginPasswordPage = LoginPasswordPage.Init(driver);
            driver.Manage().Cookies.AddCookie(new Cookie("GAPS", "1:lLKSHRt4ZRWTZc3gxtYNvNoCBP5HgmjpZJWZJc4w4uWTOFOwrU6ODCaECUVHHhE0okPFaDPFxdDhyTaJHhGVF_Nu4DLO5Q:nwvkk-qts6umTo9U"));
            driver.Manage().Cookies.AddCookie(new Cookie("LSID", "s.NL|s.UA|s.youtube:VwZWOLKme-aGdT7iPOIxIMumV76yXClj47z7oFJXcSuGhGs6whTe1W6hRz2SwIhvmQV5WQ."));
            driver.Manage().Cookies.AddCookie(new Cookie("ACCOUNT_CHOOSER", "AFx_qI6ZyDE9576mv7SJsZNIfgjOFMvWFITx2tQdU6F-8j-3fYZaQUZ4vwsUFHOTt4jc_6VB6lavT0p92cVjUwd113TJZ3UuwQ8ru2IVBukLlzMbYKeXf8yo2Ns8KqJq6A0A0bqUscSC2H84DBVG1bbAr0cI5QjXGQ"));
            return loginPasswordPage;
        }



    }
}
