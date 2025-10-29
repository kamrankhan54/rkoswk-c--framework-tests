Feature: Inventory Page

  Acceptance Criteria: 

    - Sort by high to low 
    - Display at least 1 product
    - problem user seeing same placeholder image for all products in inventory
    - inventory page not loading in the expected time for performance glitch user once signed in

Scenario: Sort products by price high to low
  Given I open the login page
  When I enter my "standard_user" username and password
  Then I should be logged in successfully
  When I sort products by "Price (high to low)"
  Then Products should be ordered by "high to low"

Scenario: Inventory page displayed with at least 1 product
  Given I open the login page
  When I enter my "standard_user" username and password
  Then I should be logged in successfully
  And The inventory should have all items displayed

Scenario: Problem user views inventory page
  Given I open the login page
  When I enter my "problem_user" username and password
  Then I should be logged in successfully
  And Product "sauce-labs-backpack" image should not have the placeholder image

Scenario: Performance glitch logs in to view inventory page
  Given I open the login page
  When I enter my "performance_glitch_user" username and password
  Then I should be logged in successfully
  And The inventory should have all items displayed