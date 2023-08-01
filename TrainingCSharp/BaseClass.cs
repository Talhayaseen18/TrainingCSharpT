using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

[TestClass]
public class BaseClass
{    
    protected static IWebDriver driver;

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
    
    [TestInitialize]
    public void TestInitialize()
    {   
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");               
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        driver.Quit();
        driver.Dispose();
    }
}