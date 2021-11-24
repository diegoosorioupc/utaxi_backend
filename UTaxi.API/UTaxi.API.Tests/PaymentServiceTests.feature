Feature: PaymentServiceTests
	As a Developer
	I want to add new Payment through API
	So that I can be available for applications

Background: 
	Given the Endpoint https://localhost:5001/api/v1/payments is available	
	
@payment-add
Scenario: Add Payment
	When a new payment request is sent
	  | TypePayment | Mont | Discount | CheckPayment |
	  | Efectivo    | 4    | 2        | True         |
	Then Response receipt with status 200
	And A Payment Resource is included in Response Body
	  | Id | TypePayment | Mont | Discount | CheckPayment |
	  | 2  | Efectivo    | 4    | 2        | True         |