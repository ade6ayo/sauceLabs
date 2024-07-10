# Sauce Labs Automated Testing with Playwright and SpecFlow

This repository contains an automated testing suite for the Sauce Labs Sample Application using Playwright and SpecFlow. The tests cover various scenarios for the 'Buy T-shirt' functionality, ensuring robust end-to-end testing capabilities.

## Technologies Used
- **Playwright**: Cross-browser automation library to control Chromium, WebKit, and Firefox.
- **SpecFlow**: Behavior-driven development (BDD) framework for defining application behavior in plain text.
- **NUnit**: Unit testing framework for .NET applications.
- **.NET C#**: Programming language for the test implementation.

## Project Structure for SauceLabs Test Automation
The project includes:
- **SpecFlow Feature Files**: Defines test scenarios in Gherkin format.
- **Step Definitions**: C# methods that implement the steps outlined in feature files.
- **Playwright Integration**: Utilizes Playwright for browser automation tasks.
- **Assertions and Verifications**: Uses Playwright's `Expect` API and NUnit assertions for verifying expected outcomes.

## Test Scenarios Covered
1. **Login Functionality**:
   - Validates successful and unsuccessful login attempts.
   - Verifies error messages for invalid credentials.
   
2. **Shopping Cart Operations**:
   - Adds items to the shopping cart and verifies cart contents.
   - Checks item details such as name, price, and description.

3. **Checkout Process**:
   - Fills in shipping details and verifies order summary.
   - Completes the purchase and confirms order completion.

## Running the Tests
To run the tests:
1. Ensure you have .NET SDK installed.
2. Clone this repository.
3. Open the solution in Jetbrains Rider or your preferred IDE.
4. Use NUnit Test Explorer to execute the SpecFlow tests.

## Configuration
- **Browser Configuration**: Tests are currently configured to run in the default browser setup by Playwright.
- **Timeout Settings**: Adjust timeouts as needed in `Page.SetDefaultTimeout()` calls.

## Notes
- **Headed Mode**: Tests can be run in headed mode using `HEADED=1 dotnet test` command to see the browser operations.
- **Selectors**: Update selectors (`[data-test="..."]`) in step definitions according to your application's HTML structure.

## Project Structure for Specflow Project

sauceLabsAuto/
├── Features/
│   └── OrderTshirts.feature
├── Drivers/
│   └── PlaywrightDriver.cs
├── Hooks/
│   └── PlaywrightHooks.cs
├── Steps/
│   └── OrderTshirtsSteps.cs
├── sauceLabsAuto.csproj
├── Program.cs
└── README.md

## Description of Key Files
OrderTshirts.feature: Contains the BDD feature and scenarios for ordering T-shirts.
PlaywrightDriver.cs: Initializes and manages the Playwright browser.
PlaywrightHooks.cs: Contains setup and teardown hooks for the tests.
OrderTshirtsSteps.cs: Implements the step definitions for the BDD scenarios.
Setup and Installation
Clone the repository:

## GITbash
git clone https://github.com/ade6ayo/sauceLabs.git
cd sauceLabs
Install .NET SDK: Ensure you have the .NET SDK installed. You can download it from here.

## Install required NuGet packages:
GITbash
dotnet add package Microsoft.Playwright
dotnet add package SpecFlow.NUnit
dotnet add package SpecFlow.Tools.MsBuild.Generation
dotnet add package Microsoft.Playwright.NUnit
Install Playwright browsers:
