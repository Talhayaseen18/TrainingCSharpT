using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCSharp.Pages
{
    internal class InventoryPage
    {
        private IWebDriver driver;
        protected IWait<IWebDriver> wait;

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators
        protected string addToCartByProduct = "//button[contains(@id, '{0}')][contains(@class, 'btn') or  contains(@class, 'Btn')]";
        protected string button = "//button[text()='{0}'][contains(@class, 'btn') or  contains(@class, 'Btn')]";
        private string text = "//*[text()='{0}']";
        protected string anchor = ".//div[text()='{0}']";
        By Cart = By.ClassName("shopping_cart_link");
        By CartNumber = By.ClassName("shopping_cart_badge");
        #endregion

        #region Method
        protected void WaitForElementToBePresent(By element)
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(element));
        }

        internal void ButtonClick(string buttonCaption)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(string.Format(button, buttonCaption))));
        }
        internal void AnchorClick(string anchorText)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(string.Format(anchor, anchorText))));
        }


        internal bool CheckForText(string text, bool WaitForElementToBeVisible = false)
        {
            if (WaitForElementToBeVisible)
            {
                try
                {
                    WaitForElementToBePresent(By.XPath(string.Format(this.text, text)));
                }
                catch (Exception e)
                {                    
                    return false;
                }
            }

            return driver.FindElements(By.XPath(string.Format(this.text, text))).Count == 1;

        }

        internal void goToCart() 
        {
            driver.FindElement(Cart).Click();
        }

        internal string getCartNumber()
        { 
           string cartNumber = driver.FindElement(CartNumber).Text;
            return cartNumber;
        }

        internal void AddToCartByName(string productCaption)
        {
            productCaption = productCaption.ToLower().Replace(' ', '-');
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(string.Format(addToCartByProduct, productCaption))));
        }

        #endregion
    }
}
