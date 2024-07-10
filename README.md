# Sauce Labs Automated Testing with Playwright and SpecFlow

This repository contains an automated testing suite for the Sauce Labs Sample Application using Playwright and SpecFlow. The tests cover various scenarios for the 'Buy T-shirt' functionality, ensuring robust end-to-end testing capabilities.

## Technologies Used
- **Playwright**: Cross-browser automation library to control Chromium, WebKit, and Firefox.
- **SpecFlow**: Behavior-driven development (BDD) framework for defining application behavior in plain text.
- **NUnit**: Unit testing framework for .NET applications.

## Project Structure
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
