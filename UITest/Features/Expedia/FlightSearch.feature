Feature: AutomationPractice Flight Search Feature
		In order to verify Flight Search functionality
	    as a business user 
		I want to check that flight search with booking amount are working correctly

@Web
@Expedia
Scenario Outline: Verify the Flight Search Functionality and total price
Given User is at Flight Search page  
And clicked on Flights and multicity tab
When user enters required details '<Flyfrom1>','<Goingto1>','<DepartureDate1>','<Travelers>','<Flyfrom2>','<Goingto2>','<DepartureDate2>' 
And Click on the search button and check the results
And Click the first result and then further click the first result under it
Then verify the flight details and total price
Examples:
| Flyfrom1 | Goingto1 | DepartureDate1  | Travelers | Flyfrom2 | Goingto2 | DepartureDate2 |
|  Delhi   |   Mumbai |	05/05/2020	    |  4        | Mumbai   | Delhi    | 05/12/2020    |
