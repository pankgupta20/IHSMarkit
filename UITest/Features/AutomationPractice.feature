Feature: AutomationPractice Login Feature
		In order to verify Login Page
	    as a business user 
		I want to check that all login scenarios are working correctly

@Web
@AutomationPractice
Scenario Outline: Verify the AutomationPractice Login Page
Given User is at Home page  
And navigates to Login Page
When user enters <username> and <password> 
And Click on the Signin button
Then correct error message <message> should be displayed
Examples:
| username				| password   | message						|
|						|	    	 |	An email address required.	|
| testuser_2@gmail.com  |		     |	Password is required.		|	
|						| Test@153   |	An email address required.	|		
| testuser_2@gmail.com  | Test@153   |  Authentication failed.		|