Feature: DriverServiceTests
	As a Developer
	I want to add new Driver through API
	So that I can be available for applications

Background: 
	Given the Endpoint https://localhost:5001/api/v1/drivers is available
	
@driver-adding
Scenario: Add Driver
	When a Post Request is sent
	| Name                      | LicensedNumber | UniversityName | UniversityCard |
	| Diaz Montoya Maria Isabel | 25478632      | U de Lima      | U214536874     |
 	Then A Response with Status 200 is received
	And A Driver Resource is included in Response Body
	| Id | Name                      | LicensedNumber | UniversityName | UniversityCard |
	| 2  | Diaz Montoya Maria Isabel | 25478632      | U de Lima      | U214536874     |