using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shared.Dtos;
using Web.Controllers;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerManagementStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext = ScenarioContext.Current;
        CustomerController customerController;
        IActionResult actionResult;
        int addedCustomerId;
        public CustomerManagementStepDefinitions()
        {

            customerController = _scenarioContext.Get<CustomerController>("customerController");
        }


        [Given(@"That customer exists in the database")]
        public async void GivenThatCustomerExistsInTheDatabase()
        {
            actionResult = await customerController.AddCustomer(new CustomerDto { Name = "Farnaz", Family = "Gerami", Email = "geramiraz@yahoo.com", BankAccounNumber = "65", CountryCode = 98, MobileNumber = 9122140796, BirthDate = DateTime.Now });
            var OkObjectResult = actionResult as OkObjectResult;
            addedCustomerId = (int)OkObjectResult.Value;

        }

        [When(@"I request to get the user by Id")]
        public async void WhenIRequestToGetTheUserById()
        {
            actionResult = await customerController.GetById(1);
        }

        [Then(@"the user must be returened and the response status code will be '([^']*)'")]
        public void ThenTheUserMustBeReturenedAndTheResponseStatusCodeWillBe(string p0)
        {
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            var OkObjectResult = actionResult as OkObjectResult;
            var customer = (CustomerDto)OkObjectResult.Value;

            Assert.AreEqual(customer.Id, 1);
        }
        [When(@"I request to get the user by not valid Id")]
        public async void WhenIRequestToGetTheUserBynotValidId()
        {
            actionResult = await customerController.GetById(18745);
        }


        [Given(@"That customer dose not exist in the database")]
        public async void GivenThatCustomerDoseNotExistInTheDatabase()
        {

        }

        [Then(@"no user should be  returened and the response is error")]
        public async void ThenNoUserShouldBeReturenedAndTheResponseIsError()
        {
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            var OkObjectResult = actionResult as OkObjectResult;
            Assert.IsNull(OkObjectResult.Value);
        }
    }
}
