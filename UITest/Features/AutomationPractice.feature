Feature: AutomationPractice Login Feature
		In order to verify Login Page
	    as a business user 
		I want to check that all login scenarios are working correctly

@Web
@AutomationPractice
Scenario Outline: Verify the AutomationPractice Login Page
Given User navigates to login page  
When user enters <'username'> and <'password'> 
And Click on the Signin button
Then correct error message <'message'> should be displayed
Examples:
| username   | password  | message						|
|			 |	    	 |	An email address required.	|
| testuser_2 |		     |	Password is required.		|	
|			 | Test@153  |	An email address required.	|		
| testuser_2 | Test@153  |  Authentication failed.		|