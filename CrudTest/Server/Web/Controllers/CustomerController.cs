using Mc2.CrudTest.Presentation.Server.CustomerFeatures.Commands.Add;
using Mc2.CrudTest.Presentation.Server.CustomerFeatures.Commands.Delete;
using Mc2.CrudTest.Presentation.Server.CustomerFeatures.Commands.Edit;
using Mc2.CrudTest.Presentation.Server.CustomerFeatures.Queries.FindPersonById;
using Mc2.CrudTest.Presentation.Server.CustomerFeatures.Queries.GetPersonsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Creates a New Customer.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> AddCustomer(CustomerDto customer)
        {
            try
            {
                return Ok(await mediator.Send(new AddCustomerCommandModel
                {
                    Family = customer.Family,
                    Name = customer.Name,
                    Email = customer.Email,
                    BankAccountNumber = customer.BankAccounNumber,
                    CountryCode = customer.CountryCode,
                    MobileNumber = customer.MobileNumber,
                    BirthDate = customer.BirthDate
                }));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        /// <summary>
        /// Gets all Customers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                return Ok(await mediator.Send(new GetAllCustomersQueryModel()));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Gets Customer Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await mediator.Send(new GetCustomerByIdQueryModel { Id = id }));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Deletes Customer Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await mediator.Send(new DeleteCustomerCommandModel { Id = id });
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Updates the Customer Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CustomerDto customer)
        {
            try
            {
                await mediator.Send(new EditCustomerCommandModel
                {
                    Id = customer.Id,
                    Family = customer.Family,
                    Name = customer.Name,
                    Email = customer.Email,
                    BankAccountNumber = customer.BankAccounNumber,
                    CountryCode = customer.CountryCode,
                    MobileNumber = customer.MobileNumber,
                    BirthDate = customer.BirthDate
                });
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
