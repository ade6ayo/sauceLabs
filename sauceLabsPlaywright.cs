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
       // Create a new Incognito browser context in headed mode with SlowMo
       // To run in headed mode input the following command on git bash "HEADED=1 dotnet test"
       
        // Navigate to Sauce Labs Webpage
        await Page.GotoAsync("https://www.saucedemo.com/");
        
        // Click username field
        await Page.Locator("[data-test=\"username\"]").ClickAsync();
        
        // Fill in the username field with "standard_user"
        await Page.Locator("[data-test=\"username\"]").FillAsync("standard_user");

        // Click the password field
        await Page.Locator("[data-test=\"password\"]").ClickAsync();

        // Invalid test case 
        // Fill in the password field with an incorrect password "secret_apple"
        await Page.Locator("[data-test=\"password\"]").FillAsync("secret_apple");

        // Click the login button
        await Page.Locator("[data-test=\"login-button\"]").ClickAsync();
        
        // Verification of the error message for the Invalid Test Case using incorrect login credentials
        await Expect(Page.Locator("[data-test=\"error\"]")).ToContainTextAsync("Epic sadface: Username and password do not match any user in this service");

        
        
        
        
    }
}