Feature: Login
	As a Agency Agent user,
	I would like to be able to login into APEX Portal

@login
Scenario Outline: Login as a Agency Agent
	Given that I navigate to the APEX Portal Url
	And I have entered <user> as username
	And I have entered <pass> as password
	And I have entered <cid> as the CID number
	When I click on Login button
	Then I should land on Apex hompage for Agency Agent role
	
	Examples:
	| user							| pass	   | cid   |
	| jimmie.carr@travelleaders.com | zaq1ZAQ! | 94326 |
