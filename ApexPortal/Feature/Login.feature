Feature: Login
	As a Agency Agent user,
	I would like to be able to login into APEX Portal

@login
Scenario: Login as Agency IC
	Given that I navigate to the APEX Portal Url
	When I have entered jimmie.carr@travelleaders.com as username
	And I have entered zaq1ZAQ! as password
	And I have entered 94326 as the CID number
	And I click on Login button
	Then I should land on Apex hompage for Agency Agent role
	
	#Examples:
	#| user							 | pass	    | cid   |
	#| jimmie.carr@travelleaders.com | zaq1ZAQ! | 94326 |
