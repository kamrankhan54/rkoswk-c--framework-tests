Feature: Login with users in different states

  Acceptance criteria:
    
    | User                    | Description                                                             |
    | ----------------------- | ----------------------------------------------------------------------- |
    | standard_user           | User should be able to login                                            |
    | locked_out_user         | User is locked out and should not be able to log in                     |

  Scenario: Standard user able to login successfully
    Given I open the login page
    When I enter my "standard_user" username and password
    Then I should be logged in successfully

  Scenario: Locked out user not able to login with correct password
    Given I open the login page
    When I enter my "locked_out_user" username and password
    Then I should not be logged in and see locked out message
