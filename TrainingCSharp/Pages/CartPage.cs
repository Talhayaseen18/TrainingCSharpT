using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCSharp.Pages
{
    internal class CartPage
    {
        private IWebDriver driver;
        protected IWait<IWebDriver> wait;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators
        #endregion

        #region Methods
        internal void goToCheckout()
        {
            InventoryPage invPage;
            invPage = new InventoryPage(driver);
            invPage.ButtonClick("Checkout");
        }
        #endregion

    }
}
