using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCSharp.Pages
{
    internal class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators
        By usernameF = By.Id("user-name");
        By passwordF = By.Id("password");
        By loginBtn = By.Id("login-button");
        #endregion

        #region Methods

        public void performLogin(string userName, string password)
        {
            string url = "https://www.saucedemo.com/";
            Assert.AreEqual(url, driver.Url, "URL Mismatch");
            Assert.AreEqual("Swag Labs", driver.Title);
            driver.FindElement(usernameF).SendKeys(userName);
            driver.FindElement(passwordF).SendKeys(password);
            driver.FindElement(loginBtn).Click();           
        }

        public void clickLoginBtn()
        {
            driver.FindElement(loginBtn).Click();
        }
        #endregion
    }
}
