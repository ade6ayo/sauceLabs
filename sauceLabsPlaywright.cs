using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace sauceLabsAuto;

public class OrderTshirts : PageTest
{

    [Test]
    public async Task OpenIncognitoBrowserAndNavigate()
    {
        // Create a new Incognito browser context in headed mode with task delay till login is successful. --
        // To run in headed mode input the following command on git bash "HEADED=1 dotnet test"
        
        // Default timeout for assertions changed to 5000ms from 3000ms
        Page.SetDefaultTimeout(5000);
        
        
        // Navigate to Sauce Labs Webpage
        await Page.GotoAsync("https://www.saucedemo.com/");
        await Task.Delay(500);
        
        // Click username field
        await Page.Locator("[data-test=\"username\"]").ClickAsync();
        await Task.Delay(500);
        
        // Fill in the username field with "standard_user"
        await Page.Locator("[data-test=\"username\"]").FillAsync("standard_user");
        await Task.Delay(500);
        
        // Click the password field
        await Page.Locator("[data-test=\"password\"]").ClickAsync();
        await Task.Delay(500);
        
        // Invalid test case 
        // Fill in the password field with an incorrect password "secret_apple"
        await Page.Locator("[data-test=\"password\"]").FillAsync("secret_apple");
        await Task.Delay(500);
        
        // Click the login button
        await Page.Locator("[data-test=\"login-button\"]").ClickAsync();
        await Task.Delay(500);
        
        // Verification of the error message for the Invalid Test Case using incorrect login credentials
        await Expect(Page.Locator("[data-test=\"error\"]")).ToContainTextAsync("Epic sadface: Username and password do not match any user in this service");
        
        // Fill in the password field with the valid password "secret_sauce"
        await Page.Locator("[data-test=\"password\"]").FillAsync("secret_sauce");
        await Task.Delay(500);
        
        // Click the login button
        await Page.Locator("[data-test=\"login-button\"]").ClickAsync();
        await Task.Delay(500);
        
        // Verify login is successful and redirected to homepage
        await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
        await Task.Delay(500);
        
        // Click on the image link of the T-shirt
        await Page.Locator("[data-test=\"item-1-img-link\"]").ClickAsync();

        // Click to go back to the products list
        await Page.Locator("[data-test=\"back-to-products\"]").ClickAsync();

        // Click on the title link of the T-shirt
        await Page.Locator("[data-test=\"item-1-title-link\"]").ClickAsync();

        // Click the add to cart button
        await Page.Locator("[data-test=\"add-to-cart\"]").ClickAsync();

        // Verify that the shopping cart badge shows T-shirt is added to cart
        await Expect(Page.Locator("[data-test=\"shopping-cart-badge\"]")).ToContainTextAsync("1");

        // Click the shopping cart link/Icon
        await Page.Locator("[data-test=\"shopping-cart-link\"]").ClickAsync();

        // Verify cart page
        await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/cart.html");

        // Verify the T-shirt name is displayed in the cart
        await Expect(Page.Locator("[data-test=\"inventory-item-name\"]")).ToContainTextAsync("Sauce Labs Bolt T-Shirt");

        // Verify the T-shirt price is displayed in the cart
        await Expect(Page.Locator("[data-test=\"inventory-item-price\"]")).ToContainTextAsync("$15.99");

        // Verify the T-shirt quantity is displayed in the cart
        await Expect(Page.Locator("[data-test=\"item-quantity\"]")).ToContainTextAsync("1");

        // Verify the T-shirt details is displayed in the cart
        await Expect(Page.Locator("[data-test=\"inventory-item-desc\"]")).ToContainTextAsync("Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.");

        // Click the checkout button
        await Page.Locator("[data-test=\"checkout\"]").ClickAsync();

        // Verify checkout information page is displayed
        await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/checkout-step-one.html");

        // Click the first name field
        await Page.Locator("[data-test=\"firstName\"]").ClickAsync();

        // Fill in the first name field
        await Page.Locator("[data-test=\"firstName\"]").FillAsync("adebayo");

        // Click the last name field
        await Page.Locator("[data-test=\"lastName\"]").ClickAsync();

        // Fill in the last name field
        await Page.Locator("[data-test=\"lastName\"]").FillAsync("adetunji");

        // Click the postal code field
        await Page.Locator("[data-test=\"postalCode\"]").ClickAsync();

        // Fill in the postal code field
        await Page.Locator("[data-test=\"postalCode\"]").FillAsync("200252");

        // Click the continue button
        await Page.Locator("[data-test=\"continue\"]").ClickAsync();

        //Verify the order summary is displayed successfully, T-shirt details and the total amount
        await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/checkout-step-two.html");
        await Expect(Page.Locator("[data-test=\"inventory-item-desc\"]")).ToContainTextAsync("Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.");
        await Expect(Page.Locator("[data-test=\"total-label\"]")).ToContainTextAsync("Total: $17.27");

        // Click the finish button to complete the purchase
        await Page.Locator("[data-test=\"finish\"]").ClickAsync();

        // Verify the order confirmation page and message
        await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/checkout-complete.html");
        await Expect(Page.Locator("[data-test=\"title\"]")).ToContainTextAsync("Checkout: Complete!");

        // Click to open the hamburger menu
        await Page.GetByRole(AriaRole.Button, new() { Name = "Open Menu" }).ClickAsync();

        // Click the logout link
        await Page.Locator("[data-test=\"logout-sidebar-link\"]").ClickAsync();

        //Verify user is logged out successfully and redirected to login page
        await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/");
        
    }
}