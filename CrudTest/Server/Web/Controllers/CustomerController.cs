using Application.Features.CustomerFeatures.Commands.Add;
using Application.Features.CustomerFeatures.Commands.Delete;
using Application.Features.CustomerFeatures.Commands.Edit;
using Application.Features.CustomerFeatures.Queries.FindCustomerByFilter;
using Application.Features.CustomerFeatures.Queries.FindCustomerById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Helper;
using Web.Helper;

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
        /// 
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByFiletr([FromQuery] PaginationDTO pagination,
            [FromQuery] CustomerFilterDto customerFilterDto)
        {
            var result = await mediator.Send(new GetCustomerByFilterQueryModel { CustomerFilterDto = customerFilterDto, PaginationDTO = pagination });

            await HttpContext.InsertPaginationParameterInResponse(result.Item2, pagination.QuantityPerPage);

            return Ok(result.Item1);

        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {

        //        return Ok(await mediator.Send(new GetAllCustomersQueryModel()));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}
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
