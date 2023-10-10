using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Users.Commands.CreateUser;
using Users.Application.Users.Commands.DeleteCommand;
using Users.Application.Users.Commands.UpdateUser;
using Users.Application.Users.Queries.GetUserDetails;
using Users.Application.Users.Queries.GetUserList;
using Users.WebApi.Models;

namespace Users.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /user
        /// </remarks>
        /// <returns>Returns UserListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var query = new GetUserListQuery
            {
                RoleId = RoleId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /user/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">User id (guid)</param>
        /// <returns>Returns UserDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            var query = new GetUserDetailsQuery
            {
                RoleId = RoleId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /user
        /// {
        /// }
        /// </remarks>
        /// <param name="createUserDto">CreateUserDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            command.RoleId = RoleId;
            var userId = await Mediator.Send(command);
            return Ok(userId);  
        }

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /user
        /// {
        /// }
        /// </remarks>
        /// <param name="updateUserDto">UpdateUserDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            command.RoleId = RoleId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /user/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the user (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand
            {
                RoleId = RoleId,
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
