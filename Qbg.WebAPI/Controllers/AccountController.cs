using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Qbg.Data;
using Qbg.IServices;
using Qbg.WebAPI.Models.User.Response;

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
        public IEnumerable<Models.User.Response.UserGet> Get()
        {
            return userService.GetUsersAsync().Select(u => new Models.User.Response.UserGet { Email = u.Email, Username = u.Username, DateCreated = u.DateCreated });
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<Models.User.Response.UserGet> Get(long id)
        {
            var userRet = await userService.GetUserAsync(id);
            return new Models.User.Response.UserGet { Email = userRet.Email, Username = userRet.Username, DateCreated = userRet.DateCreated };
        }

        [HttpGet("{id}/roles")]
        public async Task<Models.User.Response.RolesGet> GetRoles(long id)
        {
            var userRet = await userService.GetUserAsync(id, includeRoles: true);
            return new Models.User.Response.RolesGet { Roles = userRet.UserRoles?.Select(p => new RoleGet { Id = p.Role.Id, Name = p.Role.Name, Description = p.Role.Description }).ToList() };

        }

        // POST: api/Account
        [HttpPost]
        public IActionResult Post([FromBody]Models.User.Request.UserPost userReq)
        {
            if (userReq != null)
            {
                userService.InsertUserAsync(userReq.Username, userReq.Email, userReq.Password);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.User.Request.UserPost userReq)
        {
            if (userReq != null)
            {
                User user = new User { Email = userReq.Email, Username = userReq.Username, Password = userReq.Password };
                await userService.UpdateUserAsync(id, userReq.Email, userReq.Username, userReq.Password);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.User.Request.RolesPut rolesReq)
        {
            if (rolesReq != null)
            {
                User user = await userService.GetUserAsync(id);
                user.UserRoles?.Clear();
                foreach (int role in rolesReq.Roles)
                {
                    userService.AssignRoleAsync(user, (RoleEnum)role);
                }
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            userService.DeleteUserAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}

