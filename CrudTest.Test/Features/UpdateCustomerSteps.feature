Feature: UpdateCustomerStepsFeature

n order to update customer s
as an Api consumer
I want to update a customer through the Api sytem


Scenario: Update an exist customer by Id with different fields
	Given That customer exists in the system
	When I request to Update the user by Id with this details:
	| Id | Name  | Family | BirthDate  | MobileNumber | CountryCode | Email                | BankAccountNumber |
	| 1  | Paghi | Geri   | 1983-05-03 | 9122140796   | 98          | geramiraz1@yahoo.com | 14                |

	Then the user should be updated and the response status code will be '200 Ok'


@outline
Scenario Outline:Updating a customer with invalid data with different fields
	Given That customer  exists in this system
	When I request to update the user by id with some details : <Id>  and <Namee>  and <Family>  <BirthDate> and <MobileNumber> and <CountryCode> and <Email> and <BankAccountNumber>
	Then user should not  be  updated and the response is error Statecode
	Examples: 
	| Id | Namee  | Family    | BirthDate    | MobileNumber | CountryCode | Email                 | BankAccountNumber |
	| 1  | ""     | "Geramii" | "1983-05-03" | 9122140796   | 98          | "geramiraz@yahoo.com" | "14"              |
	| 1  | "Pari" | "Geramii" | "1983-05-03" | 9122140796   | 98          | "geramiraz@yahoo.com" | ""                |
	| 1  | "Pari" | "Geramii" | "1983-05-03" | 9122140796   | 98          | ""                    | "14"              |
	| 1  | "Pari" | "Geramii" | "1983-05-03" | 9122140796   | 0           | "geramiraz@yahoo.com" | "14"              |
	| 1  | "Pari" | "Geramii" | "1983-05-03" | 0            | 98          | "geramiraz@yahoo.com" | "14"              |
	| 1  | "Pari" | "Geramii" | ""           | 9122140796   | 98          | "geramiraz@yahoo.com" | "14"              |
	| 1  | "Pari" | ""        | "1983-05-03" | 9122140796   | 98          | "geramiraz@yahoo.com" | "14"              |
		



