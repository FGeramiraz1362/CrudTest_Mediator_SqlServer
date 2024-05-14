Feature: CustomerManagement

In order to get customer from API
I want to get a customer by Id


Scenario: Get an exist customer by Id 
	Given That customer exists in the database 
	When I request to get the user by Id 
	Then the user must be returened and the response status code will be '200 Ok'


Scenario: Get a not-exististing customer by Id 
	Given That customer dose not exist in the database 
	When I request to get the user by not valid Id 
	Then no user should be  returened and the response is error