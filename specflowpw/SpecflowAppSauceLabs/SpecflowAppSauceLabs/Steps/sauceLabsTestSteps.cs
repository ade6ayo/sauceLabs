using TechTalk.SpecFlow;
using Microsoft.Playwright;


namespace sauceLabsTestSteps
{
    [Binding]
    public sealed class OrderTshirtsSteps
    {
        private readonly IPage page;

        public OrderTshirtsSteps(IPage page)
        {
            this.page = page;
        }

        [Given(@"I open the Sauce Labs website")]
        public async Task GivenIOpenTheSauceLabsWebsite()
        {
            await page.GotoAsync("https://www.saucedemo.com/");
        }

        [When(@"I log in with username ""(.*)"" and password ""(.*)""")]
        public async Task WhenILogInWithUsernameAndPassword(string username, string password)
        {
            await page.Locator("[data-test=\"username\"]").ClickAsync();
            await page.Locator("[data-test=\"username\"]").FillAsync(username);
            await page.Locator("[data-test=\"password\"]").ClickAsync();
            await page.Locator("[data-test=\"password\"]").FillAsync(password);
            await page.Locator("[data-test=\"login-button\"]").ClickAsync();
            await page.WaitForNavigationAsync();
        }

        [Then(@"I should be redirected to the inventory page")]
        public async Task ThenIShouldBeRedirectedToTheInventoryPage()
        {
            await page.WaitForURLAsync("https://www.saucedemo.com/inventory.html");
        }

        [When(@"I add the T-shirt to the shopping cart")]
        public async Task WhenIAddTheTShirtToTheShoppingCart()
        {
            await page.Locator("[data-test=\"item-1-img-link\"]").ClickAsync();
            await page.Locator("[data-test=\"add-to-cart\"]").ClickAsync();
        }

        [Then(@"I should see the T-shirt in the cart with correct details")]
        public async Task ThenIShouldSeeTheTShirtInTheCartWithCorrectDetails()
        {
            await page.Locator("[data-test=\"shopping-cart-badge\"]").expect.ToContainTextAsync("1");
            await page.Locator("[data-test=\"shopping-cart-link\"]").ClickAsync();
            await page.WaitForURLAsync("https://www.saucedemo.com/cart.html");
            await page.Locator("[data-test=\"inventory-item-name\"]").Expect.ToContainTextAsync("Sauce Labs Bolt T-Shirt");
            await page.Locator("[data-test=\"inventory-item-price\"]").Expect.ToContainTextAsync("$15.99");
            await page.Locator("[data-test=\"item-quantity\"]").Expect.ToContainTextAsync("1");
            await page.Locator("[data-test=\"inventory-item-desc\"]").Expect.ToContainTextAsync("Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.");
        }

        [When(@"I proceed to checkout and fill in shipping details")]
        public async Task WhenIProceedToCheckoutAndFillInShippingDetails()
        {
            await page.Locator("[data-test=\"checkout\"]").ClickAsync();
            await page.WaitForURLAsync("https://www.saucedemo.com/checkout-step-one.html");
            await page.Locator("[data-test=\"firstName\"]").ClickAsync();
            await page.Locator("[data-test=\"firstName\"]").FillAsync("adebayo");
            await page.Locator("[data-test=\"lastName\"]").ClickAsync();
            await page.Locator("[data-test=\"lastName\"]").FillAsync("adetunji");
            await page.Locator("[data-test=\"postalCode\"]").ClickAsync();
            await page.Locator("[data-test=\"postalCode\"]").FillAsync("200252");
            await page.Locator("[data-test=\"continue\"]").ClickAsync();
            await page.WaitForURLAsync("https://www.saucedemo.com/checkout-step-two.html");
        }

        [Then(@"I should see the order summary with the correct total amount")]
        public async Task ThenIShouldSeeTheOrderSummaryWithTheCorrectTotalAmount()
        {
            await page.Locator("[data-test=\"inventory-item-desc\"]").Expect.ToContainTextAsync("Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.");
            await page.Locator("[data-test=\"total-label\"]").Expect.ToContainTextAsync("Total: $17.27");
        }

        [When(@"I complete the purchase")]
        public async Task WhenICompleteThePurchase()
        {
            await page.Locator("[data-test=\"finish\"]").ClickAsync();
            await page.WaitForURLAsync("https://www.saucedemo.com/checkout-complete.html");
        }

        [Then(@"I should see the order confirmation page")]
        public async Task ThenIShouldSeeTheOrderConfirmationPage()
        {
            await page.Locator("[data-test=\"title\"]").Expect.ToContainTextAsync("Checkout: Complete!");
        }

        [Then(@"I should be logged out successfully")]
        public async Task ThenIShouldBeLoggedOutSuccessfully()
        {
            await page.GetByRole(AriaRole.Button, new() { Name = "Open Menu" }).ClickAsync();
            await page.Locator("[data-test=\"logout-sidebar-link\"]").ClickAsync();
            await page.WaitForURLAsync("https://www.saucedemo.com/");
        }
    }
}
