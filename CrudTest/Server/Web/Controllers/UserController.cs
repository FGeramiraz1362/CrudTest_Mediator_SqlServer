using Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Add;
using Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Delete;
using Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Edit;
using Mc2.CrudTest.Presentation.Server.UserFeatures.Queries.FindPersonById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Helper;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ProtectPassword _protectPassword;

        public UserController(IMediator mediator, ProtectPassword protectPassword)
        {
            this.mediator = mediator;
            _protectPassword = protectPassword;
        }

        /// <summary>
        /// Creates a New User.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> AddUser(UserDto User)
        {
            try
            {
                return Ok(await mediator.Send(new AddUserCommandModel
                {
                    LastName = User.LastName,
                    Name = User.Name,
                    Email = User.Email,
                    Job = User.Job,
                    RoleId = User.RoleId,
                    Password = _protectPassword.HashPassword(User.Password)

                }));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        /// <summary>
        /// Gets all Users.
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByFiletr([FromQuery] PaginationDTO pagination,
            [FromQuery] UserFilterDto UserFilterDto)
        {
            return Ok(await mediator.Send(new GetUserByFilterQueryModel{ UserFilterDto= UserFilterDto  , PaginationDTO = pagination }));

        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {

        //        return Ok(await mediator.Send(new GetAllUsersQueryModel()));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}
        /// <summary>
        /// Gets User Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await mediator.Send(new GetUserByIdQueryModel { Id = id }));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Deletes User Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await mediator.Send(new DeleteUserCommandModel { Id = id });
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Updates the User Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UserDto User)
        {
            try
            {
                await mediator.Send(new EditUserCommandModel
                {
                    Id = User.Id,
                    LastName = User.LastName,
                    Name = User.Name,
                    Email = User.Email,
                    Job = User.Job,
                    RoleId= User.RoleId,
                    Password = _protectPassword.HashPassword(User.Password)

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
