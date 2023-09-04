using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TrainingCSharp.DataObjects;
using TrainingCSharp;
using TrainingCSharp.Pages;

[TestClass]
public class BaseClass
{    
    protected static IWebDriver driver;
    LoginPage loginPage;

    //[TestInitialize]
    //public static void AssemblyInitialize(TestContext context)
    //{
    //    driver = new ChromeDriver();
    //    driver.Manage().Window.Maximize();
    //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    //}
    
    [TestInitialize]
    public void TestInitialize()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        Credentials credentials = CredentialHelper.ReadCredentials("EnviromentProperties\\credentials.json");        
        driver.Navigate().GoToUrl(credentials.Url);              
        loginPage = new LoginPage(driver);
        loginPage.performLogin(credentials.Username, credentials.Password);
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        driver.Quit();
        driver.Dispose();
    }
}