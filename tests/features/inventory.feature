Feature: Inventory Page

  Acceptance Criteria: 

    - Sort by high to low 
    - Display at least 1 product

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