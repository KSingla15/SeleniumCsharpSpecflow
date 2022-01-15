Feature: GoogleSearch
	Simple calculator for adding two numbers

@mytag
Scenario: Validate search result
	Given I am on the Google search page
	When I search "Automation Testing"
	Then I should be navigated to result page