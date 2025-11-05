Feature: Placing order with products

  Acceptance Criteria:
    
    - Standard user places order from inventory page
    - Standard user places order from product page

Scenario: Standard user places order with single product from inventory page
  Given I open the login page
  When I enter my "standard_user" username and password
  Then I should be logged in successfully
  Given I add "Sauce Labs Backpack" product to cart
  When I open the cart page
  Then The cart should have 1 items
  When I click checkout
  And Complete my information using first name "Kamran" last name "Khan" postcode "IG3 9XG"
  Then The checkout overview page is displayed for "Sauce Labs Backpack" product
  When I click finish
  Then The thank for your order page is displayed

Scenario: Standard user places order with single product from product page
  Given I open the login page
  When I enter my "standard_user" username and password
  Then I should be logged in successfully

  Given I go to the "Sauce Labs Backpack" product page
  And I add product to cart
  When I open the cart page
  Then The cart should have 1 items
  When I click checkout
  And Complete my information using first name "Kamran" last name "Khan" postcode "IG3 9XG"
  Then The checkout overview page is displayed for "Sauce Labs Backpack" product
  When I click finish
  Then The thank for your order page is displayed