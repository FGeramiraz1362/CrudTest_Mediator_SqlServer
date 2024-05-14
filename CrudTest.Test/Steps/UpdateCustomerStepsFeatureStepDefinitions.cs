using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shared.Dtos;
using TechTalk.SpecFlow.Assist;
using Web.Controllers;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class UpdateCustomerStepsFeatureStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext = ScenarioContext.Current;
        CustomerController customerController;
        IActionResult actionResult;
        int addedCustomerId;
        public UpdateCustomerStepsFeatureStepDefinitions()
        {

            customerController = _scenarioContext.Get<CustomerController>("customerController");
        }

        [Given(@"That customer exists in the system")]
        public async void GivenThatCustomerExistsInTheSystem()
        {
            var actionResult = await customerController.AddCustomer(new CustomerDto { Name = "Farnaz", Family = "Gerami", Email = "geramiraz@yahoo.com", BankAccounNumber = "65", CountryCode = 98, MobileNumber = 9122140796, BirthDate = DateTime.Now });
            var OkObjectResult = actionResult as OkObjectResult;
            addedCustomerId = (int)OkObjectResult.Value;
        }

        [When(@"I request to Update the user by Id with this details:")]
        public async void WhenIRequestToUpdateTheUserByIdWithThisDetails(Table table)
        {
            var updateCustomerDataTable = table.CreateInstance<UpdateCustomerDataTable>();

            actionResult = await customerController.Update(
                new CustomerDto
                {
                    Name = updateCustomerDataTable.Name,
                    Family = updateCustomerDataTable.Family,
                    BirthDate = DateTime.Parse(updateCustomerDataTable.BirthDate),
                    BankAccounNumber = updateCustomerDataTable.BankAccountNumber,
                    MobileNumber = updateCustomerDataTable.MobileNumber,
                    CountryCode = updateCustomerDataTable.CountryCode,
                    Email = updateCustomerDataTable.Email,
                    Id = updateCustomerDataTable.Id,
                });
        }

        [Then(@"the user should be updated and the response status code will be '([^']*)'")]
        public void ThenTheUserShouldBeUpdatedAndTheResponseStatusCodeWillBe(string p0)
        {
            if (p0 == "200 Ok")
            {
                Assert.IsInstanceOf<OkResult>(actionResult);
            }
        }

        [Given(@"That customer  exists in this system")]
        public async void GivenThatCustomerExistsInThisSystem()
        {
            var actionResult = await customerController.AddCustomer(new CustomerDto { Name = "Farnaz1", Family = "Geramiio", Email = "geramiraz87@yahoo.com", BankAccounNumber = "65", CountryCode = 98, MobileNumber = 9122140796, BirthDate = DateTime.Now });
            var OkObjectResult = actionResult as OkObjectResult;
            addedCustomerId = (int)OkObjectResult.Value;
        }

        [When(@"I request to update the user by id with some details : (.*)  and ""([^""]*)""  and ""([^""]*)""  ""([^""]*)"" and (.*) and (.*) and ""([^""]*)"" and ""([^""]*)""")]
        public async void WhenIRequestToUpdateTheUserByIdWithSomeDetailsAndAndAndAndAndAnd(int id, string name, string family, string birthdate, ulong mobileNumber, uint countryCode, string email, string bankAccountNumber)
        {
            _scenarioContext["actionResult"] = await customerController.Update(
                new CustomerDto
                {
                    Id = id,
                    Name = name,
                    Family = family,
                    BirthDate = string.IsNullOrEmpty(birthdate) ? DateTime.MinValue : DateTime.Parse(birthdate),
                    BankAccounNumber = bankAccountNumber,
                    MobileNumber = mobileNumber,
                    CountryCode = countryCode,
                    Email = email,
                });
        }

        [Then(@"user should not  be  updated and the response is error Statecode")]
        public void ThenUserShouldNotBeUpdatedAndTheResponseIsErrorStateCode()
        {
            Assert.IsInstanceOf<BadRequestObjectResult>(_scenarioContext.Get<IActionResult>("actionResult"));
        }



    }
    class UpdateCustomerDataTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string BirthDate { get; set; }
        public ulong MobileNumber { get; set; }
        public uint CountryCode { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
