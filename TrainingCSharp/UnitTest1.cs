using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingCSharp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://10pearlsuniversity.org/");           
            Assert.AreEqual("Home - 10PEARLS University", driver.Title, "Title Mismatch");
            driver.Navigate().GoToUrl("https://www.facebook.com");
            driver.Navigate().Back();
            Console.WriteLine(driver.Url);
            driver.Navigate().Refresh();
            driver.Quit();
        }

        [TestMethod]
        public void TestMethod2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Assert.AreEqual("https://www.saucedemo.com/", driver.Url, "URL Mismatch");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            Assert.IsTrue(driver.FindElement(By.ClassName("inventory_item_name")).Displayed, "Not logged in successfully");
            driver.Quit();
        }
    }
}