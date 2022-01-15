Feature: ExecuteAutomation
Simple calculator for adding two numbers

@functional
  Scenario: Validate login error message for invalid credentials
    Given I am on Login page of Execute Automation
     When I login with invalid credentials
     Then Error message "Invalid login attempt." should be displayed
  
  Scenario Outline: Register a new user
    Given I am on Registration page of the portal
     When I register user with following details
      | UserName   | Password   | Confirm Password   | Email   | 
      | <UserName> | <Password> | <Confirm Password> | <Email> | 
     Then "<Message>" should be displayed
    Examples: 
      | UserName | Password  | Confirm Password | Email | Message                                                                                                       |
      |          |           |                  |       | The UserName field is required.;The Password field is required.;The Email field is required.                  |
      | Test     |           |                  |       | The UserName must be at least 6 charecters long.;The Password field is required.;The Email field is required. |
      | Test12   | Test1234! |                  |       | The password and confirmation password do not match.;The Email field is required.                             |