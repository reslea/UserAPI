using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Commands;
using UserAPI.Models;
using UserAPI.Queries;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/User
        /// <summary>
        /// Get list of users
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);

            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post(UserModel model)
        {
            var command = _mapper.Map<CreateUserCommand>(model);
            var createdUser = await _mediator.Send(command);

            if (createdUser == null)
            {
                return BadRequest();
            }
            return Created($"/api/user/{createdUser.Id}", createdUser);
        }

        // PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    if (id > _users.Count)
        //        return NotFound();
        //    else
        //    {
        //        _users.RemoveAt(id-1);
        //        return Ok();
        //    }
        //}
    }
}
