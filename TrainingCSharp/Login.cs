using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;

namespace TrainingCSharp
{    
    [TestClass]
    public class Login : Hooks   
    {
        protected IWait<IWebDriver> wait;

        public void AcceptAlert() 
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        [Priority(1)]
        public void PostiveTest1()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, driver.Url, "URL Mismatch");
            Assert.AreEqual("Swag Labs", driver.Title);            
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url,"Inventory URL Mismatch");
        }

        [TestMethod]
        [Priority(2)]
        public void PostiveTest2()
        {          
            Assert.AreEqual("Swag Labs", driver.Title);
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "Inventory URL Mismatch");
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            Assert.AreEqual("https://www.saucedemo.com/cart.html", driver.Url, "Cart URL Mismatch");
        }

        [TestMethod]
        public void NegativeTest1()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, driver.Url, "URL Mismatch");
            Assert.AreEqual("Swag Labs", driver.Title);
            driver.FindElement(By.Id("user-name")).SendKeys("locked_out_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            IWebElement lockErrorElement = driver.FindElement(By.XPath("//div[contains(@class,'error-message-container error')]/h3"));
            string lockError = lockErrorElement.Text;
            Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", lockError, "Error Mismatch");
        }

        [TestMethod]
        public void NegativeTest2()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, driver.Url, "URL Mismatch");
            Assert.AreEqual("Swag Labs", driver.Title);
            driver.FindElement(By.Id("user-name")).SendKeys("locked_out_user");
            driver.FindElement(By.Id("password")).SendKeys("abc");
            driver.FindElement(By.Id("login-button")).Click();
            IWebElement lockErrorElement = driver.FindElement(By.XPath("//div[contains(@class,'error-message-container error')]/h3"));
            string lockError = lockErrorElement.Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", lockError, "Error Mismatch");
        }

        [TestMethod]
        public void NegativeTest3()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, driver.Url, "URL Mismatch");
            Assert.AreEqual("Swag Labs", driver.Title);
            driver.FindElement(By.Id("user-name")).SendKeys("locked_out_user");
            driver.FindElement(By.Id("login-button")).Click();
            IWebElement lockErrorElement = driver.FindElement(By.XPath("//div[contains(@class,'error-message-container error')]/h3"));
            string lockError = lockErrorElement.Text;
            Assert.AreEqual("Epic sadface: Password is required", lockError, "Error Mismatch");
        }

        [TestMethod]
        public void PostivieTest3()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, driver.Url, "URL Mismatch");
            Assert.AreEqual("Swag Labs", driver.Title);
            driver.FindElement(By.Id("user-name")).SendKeys("performance_glitch_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            IWebElement inventoryElement = driver.FindElement(By.XPath("//a[contains(@id,'item_4_title_link')]/div"));
            string inventoryText = inventoryElement.Text;
            Assert.AreEqual("Sauce Labs Backpack", inventoryText, "Error Mismatch");
        }
    }
}


