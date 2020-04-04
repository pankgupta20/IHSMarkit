Feature: Get Users
			In order to verify registered users
			as a business user 
			I want to check that the get user API is correct


@API
Scenario Outline: Verify the get user request
Given I want to send a request on '<endpoint>'
When I send the request
Then Response is returned with code '<responsecode>'
Examples: 
| endpoint | responsecode |
|/users	 | OK |