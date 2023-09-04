using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCSharp.DataObjects;
using TrainingCSharp.Pages;

namespace TrainingCSharp.Tests
{

    [TestClass]
    public class CheckoutModule : BaseClass
    {

        [TestMethod]
        public void PostiveCase1()
        {
            InventoryPage inventoryPage = new InventoryPage(driver);
            CheckoutPage checkoutPage = new CheckoutPage(driver);
            CartPage cartPage = new CartPage(driver);
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "Inventory URL Mismatch");
            Assert.IsTrue(inventoryPage.CheckForText("Sauce Labs Backpack"),"Item not present");
            inventoryPage.AnchorClick("Sauce Labs Backpack");
            Assert.AreEqual("https://www.saucedemo.com/inventory-item.html?id=4", driver.Url, "Inventory URL Mismatch");
            inventoryPage.ButtonClick("Add to cart");
            Assert.IsTrue(inventoryPage.CheckForText("Remove"), "Item not added");
            inventoryPage.goToCart();
            Assert.AreEqual("https://www.saucedemo.com/cart.html", driver.Url, "cart URL Mismatch");
            cartPage.goToCheckout();
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", driver.Url, "Checkout 1 URL Mismatch");
            Credentials credentials = CredentialHelper.ReadCredentials("EnviromentProperties\\credentials.json");
            checkoutPage.ProceedToCheckout1(credentials.FirstName, credentials.LastName, credentials.ZipCode);
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-two.html", driver.Url, "Checkout 2 URL Mismatch");            
            inventoryPage.ButtonClick("Finish");
            Assert.IsTrue(inventoryPage.CheckForText("Thank you for your order!"));
            Assert.AreEqual("https://www.saucedemo.com/checkout-complete.html", driver.Url, "Checkout Complete URL Mismatch");
            Console.WriteLine("Sauce Labs Backpack is successfully checkedout");
        }

        [TestMethod]
        public void PostiveCase2()
        {
            CheckoutPage checkoutPage = new CheckoutPage(driver);
            CartPage cartPage = new CartPage(driver);
            InventoryPage inventoryPage = new InventoryPage(driver);            
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "Inventory URL Mismatch");
            inventoryPage.AddToCartByName("Sauce Labs Bike Light");
            Assert.AreEqual("1", inventoryPage.getCartNumber());
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            Assert.AreEqual("2", inventoryPage.getCartNumber());
            inventoryPage.goToCart();
            Assert.AreEqual("https://www.saucedemo.com/cart.html", driver.Url, "cart URL Mismatch");
            cartPage.goToCheckout();
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", driver.Url, "Checkout 1 URL Mismatch");
            Credentials credentials = CredentialHelper.ReadCredentials("EnviromentProperties\\credentials.json");
            checkoutPage.ProceedToCheckout1(credentials.FirstName, credentials.LastName, credentials.ZipCode);
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-two.html", driver.Url, "Checkout 2 URL Mismatch");
            inventoryPage.ButtonClick("Finish");
            Assert.IsTrue(inventoryPage.CheckForText("Thank you for your order!"));
            Assert.AreEqual("https://www.saucedemo.com/checkout-complete.html", driver.Url, "Checkout Complete URL Mismatch");
            Console.WriteLine("Sauce Labs Bike Light is successfully checkedout");
            Console.WriteLine("Sauce Labs Backpack is successfully checkedout");
        }

        [TestMethod]
        public void NegativeCase1()
        {
            CheckoutPage checkoutPage = new CheckoutPage(driver);
            CartPage cartPage = new CartPage(driver);
            InventoryPage inventoryPage = new InventoryPage(driver);
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "Inventory URL Mismatch");
            inventoryPage.AddToCartByName("Sauce Labs Bike Light");
            Assert.AreEqual("1", inventoryPage.getCartNumber());
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            Assert.AreEqual("2", inventoryPage.getCartNumber());
            inventoryPage.goToCart();
            Assert.AreEqual("https://www.saucedemo.com/cart.html", driver.Url, "cart URL Mismatch");
            cartPage.goToCheckout();
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", driver.Url, "Checkout 1 URL Mismatch");
            Credentials credentials = CredentialHelper.ReadCredentials("EnviromentProperties\\credentials.json");
            checkoutPage.ProceedToCheckout1(string.Empty,credentials.LastName, credentials.ZipCode);
            checkoutPage.checkErrorMsg("Error: First Name is required");
        }

        [TestMethod]
        public void NegativeCase2()
        {
            CheckoutPage checkoutPage = new CheckoutPage(driver);
            CartPage cartPage = new CartPage(driver);
            InventoryPage inventoryPage = new InventoryPage(driver);
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "Inventory URL Mismatch");
            inventoryPage.AddToCartByName("Sauce Labs Bike Light");
            Assert.AreEqual("1", inventoryPage.getCartNumber());
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            Assert.AreEqual("2", inventoryPage.getCartNumber());
            inventoryPage.goToCart();
            Assert.AreEqual("https://www.saucedemo.com/cart.html", driver.Url, "cart URL Mismatch");
            cartPage.goToCheckout();
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", driver.Url, "Checkout 1 URL Mismatch");
            Credentials credentials = CredentialHelper.ReadCredentials("EnviromentProperties\\credentials.json");
            checkoutPage.ProceedToCheckout1(credentials.FirstName, string.Empty, credentials.ZipCode);
            checkoutPage.checkErrorMsg("Error: Last Name is required");
        }

        [TestMethod]
        public void NegativeCase3()
        {
            CheckoutPage checkoutPage = new CheckoutPage(driver);
            CartPage cartPage = new CartPage(driver);
            InventoryPage inventoryPage = new InventoryPage(driver);
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "Inventory URL Mismatch");
            inventoryPage.AddToCartByName("Sauce Labs Bike Light");
            Assert.AreEqual("1", inventoryPage.getCartNumber());
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            Assert.AreEqual("2", inventoryPage.getCartNumber());
            inventoryPage.goToCart();
            Assert.AreEqual("https://www.saucedemo.com/cart.html", driver.Url, "cart URL Mismatch");
            cartPage.goToCheckout();
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", driver.Url, "Checkout 1 URL Mismatch");
            Credentials credentials = CredentialHelper.ReadCredentials("EnviromentProperties\\credentials.json");
            checkoutPage.ProceedToCheckout1(credentials.FirstName, credentials.LastName, string.Empty);
            checkoutPage.checkErrorMsg("Error: Postal Code is required");

        }
    }
}
