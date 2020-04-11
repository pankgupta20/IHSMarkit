Feature: AutomationPractice Flight Search Feature
		In order to verify Flight Search functionality
	    as a business user 
		I want to check that flight search with booking amount are working correctly

@Web
@Expedia
Scenario: Verify the Flight Search Functionality and total price
Given User is at Flight Search page  
And clicked on Flights and multicity tab
When user enters required flight search details
And Click on the search button and check the results
And Click the first result and then further click the first result under it
Then verify the flight details and total price
