using TechTalk.SpecFlow;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SpecflowAppSauceLabs.Drivers;

namespace sauceLabsTestSteps
{
    [Binding]
    public sealed class OrderTshirtsSteps 
    {
        private readonly Driver _driver;

        public OrderTshirtsSteps(Driver driver)
        {
            _driver = driver;
        }

        [Given(@"I open the Sauce Labs website")]
        public async Task GivenIOpenTheSauceLabsWebsite()
        {
            await _driver.Page.GotoAsync("https://www.saucedemo.com/");
        }

        [When(@"I log in with username ""(.*)"" and password ""(.*)""")]
        public async Task WhenILogInWithUsernameAndPassword(string username, string password)
        {
            await _driver.Page.FillAsync("[data-test=\"username\"]", username);
            await _driver.Page.FillAsync("[data-test=\"password\"]", password);
            await _driver.Page.ClickAsync("[data-test=\"login-button\"]");
             _driver.Page.WaitForNavigationAsync();                     
        }

        [Then(@"I should be redirected to the inventory page")]
        public async Task ThenIShouldBeRedirectedToTheInventoryPage()
        {
            await _driver.Page.WaitForURLAsync("https://www.saucedemo.com/inventory.html");
        }

        [When(@"I add the T-shirt to the shopping cart")]
        public async Task WhenIAddTheTShirtToTheShoppingCart()
        {
            await _driver.Page.ClickAsync("[data-test=\"add-to-cart-sauce-labs-bolt-t-shirt\"]");
        }

        [Then(@"I should see the T-shirt in the cart with correct details")]
        public async Task ThenIShouldSeeTheTShirtInTheCartWithCorrectDetails()
        {
                        Assert.AreEqual("1", await _driver.Page.Locator("[data-test=\"shopping_cart_badge\"]").TextContentAsync());
                        await _driver.Page.ClickAsync("[data-test=\"shopping_cart_link\"]");
                        await _driver.Page.WaitForURLAsync("https://www.saucedemo.com/cart.html");
                        Assert.AreEqual("Sauce Labs Bolt T-Shirt", await _driver.Page.Locator(".inventory_item_name").TextContentAsync());
                        Assert.AreEqual("$15.99", await _driver.Page.Locator(".inventory_item_price").TextContentAsync());
                        Assert.AreEqual("1", await _driver.Page.Locator(".cart_quantity").TextContentAsync());
                        StringAssert.Contains("Get your testing superhero on with the Sauce Labs bolt T-shirt.", await _driver.Page.Locator(".inventory_item_desc").TextContentAsync());
        }

        private object Expect(ILocator locator)
        {
            throw new NotImplementedException();
        }

        [When(@"I proceed to checkout and fill in shipping details")]
        public async Task WhenIProceedToCheckoutAndFillInShippingDetails()
        {
            await _driver.Page.ClickAsync("[data-test=\"checkout\"]");
            await _driver.Page.WaitForURLAsync("https://www.saucedemo.com/checkout-step-one.html");
            await _driver.Page.FillAsync("[data-test=\"firstName\"]", "adebayo");
            await _driver.Page.FillAsync("[data-test=\"lastName\"]", "adetunji");
            await _driver.Page.FillAsync("[data-test=\"postalCode\"]", "200252");
            await _driver.Page.ClickAsync("[data-test=\"continue\"]");
            await _driver.Page.WaitForURLAsync("https://www.saucedemo.com/checkout-step-two.html");
        }

        [Then(@"I should see the order summary with the correct total amount")]
        public async Task ThenIShouldSeeTheOrderSummaryWithTheCorrectTotalAmount()
        {
          StringAssert.Contains("Get your testing superhero on with the Sauce Labs bolt T-shirt.", await _driver.Page.Locator(".inventory_item_desc").TextContentAsync());
          StringAssert.Contains("Total: $17.27", await _driver.Page.Locator(".summary_total_label").TextContentAsync());
        }

        [When(@"I complete the purchase")]
        public async Task WhenICompleteThePurchase()
        {
            _driver.Page.ClickAsync("[data-test=\"finish\"]");
            _driver.Page.WaitForURLAsync("https://www.saucedemo.com/checkout-complete.html");
        }

        [Then(@"I should see the order confirmation page")]
        public async Task ThenIShouldSeeTheOrderConfirmationPage()
        {
            Assert.AreEqual("THANK YOU FOR YOUR ORDER", await _driver.Page.Locator(".complete-header").TextContentAsync());
        }

        [Then(@"I should be logged out successfully")]
        public async Task ThenIShouldBeLoggedOutSuccessfully()
        {
            _driver.Page.ClickAsync("#react-burger-menu-btn");
            _driver.Page.ClickAsync("#logout_sidebar_link");
            _driver.Page.WaitForURLAsync("https://www.saucedemo.com/");
        }
    }
}