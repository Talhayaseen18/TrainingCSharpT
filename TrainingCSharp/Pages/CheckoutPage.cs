using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCSharp.Pages
{
    internal class CheckoutPage
    {
        private IWebDriver driver;
        protected IWait<IWebDriver> wait;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators
        By FirstName = By.Id("first-name");
        By LastName = By.Id("last-name");
        By ZipCode = By.Id("postal-code");
        By Continue = By.Id("continue");

        #endregion

        #region Methods
        internal void ProceedToCheckout1(string firstName, string lastName, string zipCode)
        {
            driver.FindElement(FirstName).SendKeys(firstName);
            driver.FindElement(LastName).SendKeys(lastName);
            driver.FindElement(ZipCode).SendKeys(zipCode);
            driver.FindElement(Continue).Click();
        }

        internal void checkErrorMsg(string errorMessage) 
        {
            IWebElement errorMsg = driver.FindElement(By.XPath("//div[contains(@class,'error-message-container error')]/h3"));
            Assert.AreEqual(errorMessage, errorMsg.Text,"Error Message Mismatch");
        }
        #endregion

    }
}
