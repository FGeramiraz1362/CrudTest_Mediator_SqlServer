# CRUD Code Test 


This is a simple CRUD application with .NET that implements the below model:
```
Customer {
	FirstName
	LastName
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
It includes:

- [TDD]
- [DDD]
- [BDD]
- [Clean architecture]
- [CQRS]


### Validations :

- During Create; the phone number is validated to be a valid *mobile* to validate number at the backend.

- A Valid email 

- Customers are unique in the database: By `Firstname`, `Lastname`, and `DateOfBirth`.

- Email is unique in the database.


### Includes:
Login
paging

