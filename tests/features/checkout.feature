Feature: Placing order with products

  Acceptance Criteria:
    
    - Standard user places order
    - Problem user tries to places order
    - Performance glitch user tries to place order
    - Error user tries to place order
    - Visual user tries to place order


Scenario: Standard user places order with single product
  Given I open the login page
  When I enter my "standard_user" username and password
  Then I should be logged in successfully
  Given I add "Sauce Labs Backpack" product to cart
  When I open the cart page
  Then The cart should have 1 items
  When I click checkout
  And Complete my information using first name "Kamran" last name "Khan" postcode "IG3 9XG"
  And I click continue
  Then The checkout overview page is displayed for "Sauce Labs Backpack" product
  When I click finish
  Then The thank for your order page is displayed



Scenario: Problem user tries to place order 
Scenario: Performance glitch user tries to place order 
Scenario: Error user tries to place order
Scenario: Visual user tries to place order 