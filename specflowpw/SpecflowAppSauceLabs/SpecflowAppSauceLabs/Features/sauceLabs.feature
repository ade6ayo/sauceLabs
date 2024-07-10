Feature: Order T-shirts on Sauce Labs

    Scenario: Order a T-shirt from Sauce Labs
        Given I open the Sauce Labs website
        When I log in with username "standard_user" and password "secret_sauce"
        Then I should be redirected to the inventory page
        When I add the T-shirt to the shopping cart
        Then I should see the T-shirt in the cart with correct details
        When I proceed to checkout and fill in shipping details
        Then I should see the order summary with the correct total amount
        When I complete the purchase
        Then I should see the order confirmation page
        And I should be logged out successfully