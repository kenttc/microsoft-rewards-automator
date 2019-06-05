Feature: Automated reward points collection
	In order to get points from microsoft rewards automatically 
	As a math idiot
	I want to be able to run this test to automatically search and click 30 times in order to get the points 

Background: 
Given I have a edge browser

@reward-points
Scenario: To get reward points automatically
	Given I have 20 random words from a random word generator website
	And I have navigated to http://bing.com
	When I loop through the search text
	Then I should have searched 10 times
