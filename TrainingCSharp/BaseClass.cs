using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestClass]
public class BaseClass
{    
    protected static IWebDriver driver;

    [AssemblyInitialize]
    [TestInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        driver.Quit();
        driver.Dispose();
    }
}