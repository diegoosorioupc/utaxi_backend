Feature: DetailsRouteServiceTests
	As a Developer
	I want to add new Details Route through API
	So that I can be available for applications
	
Background: 
	Given the Endpoint https://localhost:5001/api/v1/detailsroute is available	

@detailsRoute-adding
Scenario: Add Details Route
	When a Post Request the detail is sent
	| RouteCode | Date                  | RouteStart       | RouteEnd       | Price | Description                                                |
	| 214568745 | 15 de Agosto del 2021 | Plaza San Miguel | UPC Monterrico | 4     | Salida de Plaza San Miguel hacia UPC Monterrico a las 4 pm |
 	Then Response with Status 200 is received
	And A Details Route Resource is included in Response Body
	| Id | RouteCode | Date                  | RouteStart       | RouteEnd       | Price | Description                                                |
	| 2  | 214568745 | 15 de Agosto del 2021 | Plaza San Miguel | UPC Monterrico | 4     | Salida de Plaza San Miguel hacia UPC Monterrico a las 4 pm |