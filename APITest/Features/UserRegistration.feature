Feature: User Registration
			In order to verify User Registration
			as a business user 
			I want to check that the User Registration API is correct

@API
Scenario Outline: Verify the user is registered successfully
Given I want to send a request on '<endpoint>'
When I send the '<email>' and '<password>' in the payload
Then Response is returned with code '<responsecode>'
Examples: 
| email              | password | endpoint | responsecode |
| eve.holt@reqres.in | password | /register  | OK	      |

@API
Scenario Outline: Verify the user is not registered when password in Blank
Given I want to send a request on '<endpoint>'
When I send the '<email>' and '<password>' in the payload
Then Response is returned with code '<responsecode>'
Examples: 
| email              | password | endpoint | responsecode |
| eve.holt@reqres.in |          | /register  | BadRequest |