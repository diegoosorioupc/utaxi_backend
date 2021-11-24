Feature: TaxiServiceTests
	As a Developer
	I want to add new Taxi through API
	So that I can be available for applications

Background: 
	Given the Endpoint https://localhost:5001/api/v1/taxis is available	
	
@taxi-adding
Scenario: Add Taxi 
	When a Vehicle Post Request is sent
	  | Model       | RegistrationNumber | VehicleStatus | Capacity |
	  | Kia Picanto | 245896             | Semi Nuevo    | 5        |
	Then A Response is received with status 200
	And A Taxi Resource is included in Response Body
	  | Id | Model       | RegistrationNumber | VehicleStatus | Capacity |
	  | 2  | Kia Picanto | 245896             | Semi Nuevo    | 5        |