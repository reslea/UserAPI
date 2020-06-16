using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly List<UserModel> _users = new List<UserModel>
        {
            new UserModel {FName = "Sergey", LName = "Zhizhko", Value = "11r3start11@gmail.com"},
            new UserModel {FName = "John", LName = "Doe", Value = "john.doe@microsoft.com"}
        };

        // GET: api/User
        /// <summary>
        /// Get list of users
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public IActionResult Get()
        {
            if (_users.Any())
            {
                return Ok(_users);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id > _users.Count)
            {
                return NotFound();
            }

            return Ok(_users[id-1]);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post(UserModel value)
        {
            _users.Add(value);
            var index = _users.IndexOf(value)+1;
            return Created($"/api/user/{index}", value);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > _users.Count)
                return NotFound();
            else
            {
                _users.RemoveAt(id-1);
                return Ok();
            }
        }
    }
}
