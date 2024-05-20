using Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Add;
using Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Delete;
using Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Edit;
using Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.FindPersonById;
using Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.GetRolsList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Helper;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Creates a New Role.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> AddRole(RoleDto Role)
        {
            try
            {
                return Ok(await mediator.Send(new AddRoleCommandModel
                {
                    FnCaption = Role.FnCaption,
                    EnCaption = Role.EnCaption,
                   
                }));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        /// <summary>
        /// Gets all Roles.
        /// </summary>
        /// <returns></returns>
        /// 
        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetByFiletr([FromQuery] PaginationDTO pagination,
        //    [FromQuery] RoleFilterDto RoleFilterDto)
        //{
        //    return Ok(await mediator.Send(new GetRoleByFilterQueryModel{ RoleFilterDto= RoleFilterDto  , PaginationDTO = pagination }));

        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                return Ok(await mediator.Send(new GetAllRolesQueryModel()));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Gets Role Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await mediator.Send(new GetRoleByIdQueryModel { Id = id }));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Deletes Role Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await mediator.Send(new DeleteRoleCommandModel { Id = id });
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Updates the Role Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(RoleDto Role)
        {
            try
            {
                await mediator.Send(new EditRoleCommandModel
                {
                    Id = Role.Id,
                    FnCaption = Role.FnCaption,
                    EnCaption = Role.EnCaption,
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
