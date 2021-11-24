Feature: StudentServiceTests
	As a Developer
	I want to add new Student through API
	So that I can be available for applications
	
Background: 
	Given the Endpoint https://localhost:5001/api/v1/students is available

@student-adding
Scenario: Add Student
	When a Student Post Request is sent
	  | Name                      | Birth                   | Phone     | UniversityName | UniversityCard |
	  | Diaz Montoya Maria Isabel | 22 de Noviembre de 1996 | 958471256 | U de Lima      | U214536874     |
	Then A response is received with status 200
	And A Student Resource is included in Response Body
	  | Id | Name                      | Birth                   | Phone     | UniversityName | UniversityCard |
	  | 2  | Diaz Montoya Maria Isabel | 22 de Noviembre de 1996 | 958471256 | U de Lima      | U214536874     |