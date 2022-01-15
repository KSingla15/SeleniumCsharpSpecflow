Feature: Dummy
	Simple calculator for adding two numbers

@mytag
Scenario Outline: Add two numbers
	Given two numbers are
	| First   | Second   |
	| <First> | <Second> |
	When the two numbers are added
	Then the result should be <Expected>
	Examples: 
	| First | Second | Expected |
	| 50    | 70     | 120      |
	| 100   | -90    | 10       |