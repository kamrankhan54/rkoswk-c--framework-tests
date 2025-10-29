Feature: Cart Page

  Acceptance Criteria:

    - Cart with no products 
    - Add product to cart
    - Remove product from cart

Scenario: User views empty cart
  Given I open the login page
  When I enter my "standard_user" username and password
  Then I should be logged in successfully
  When I open the cart page
  Then The cart page should be empty

Scenario: User has single product in cart
  Given I open the login page
  When I enter my "standard_user" username and password
  Then I should be logged in successfully
  Given I add "Sauce Labs Backpack" product to cart
  When I open the cart page
  Then The cart should have 1 items
  And The product in cart should be "Sauce Labs Backpack"

Scenario: User removes single product from cart
  Given I open the login page
  When I enter my "standard_user" username and password
  Then I should be logged in successfully
  
  Given I add "Sauce Labs Backpack" product to cart
  When I open the cart page
  Then The cart should have 1 items
  And The product in cart should be "Sauce Labs Backpack"

  Given I remove "Sauce Labs Backpack" product from cart
  Then The cart page should be empty
  