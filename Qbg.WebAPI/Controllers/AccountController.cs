using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qbg.Data;
using Qbg.IServices;

namespace Qbg.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/Account
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userService.GetUsers();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public User Get(long id)
        {
            return userService.GetUser(id);
        }
        
        // POST: api/Account
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            user.AssignRole(new Role(RoleEnum.Queuer));
            if (user != null)
            {
                userService.InsertUser(user);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        
        // PUT: api/Account/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]User user)
        {
            if (user != null)
            {
                userService.UpdateUser(id, user);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            userService.DeleteUser(id);
        }
    }
}
