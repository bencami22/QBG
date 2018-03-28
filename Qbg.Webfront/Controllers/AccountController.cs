using Microsoft.AspNetCore.Mvc;
using Qbg.Data;
using Qbg.IServices;
using Qbg.Webfront.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qbg.Webfront.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;


        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserLogin userLoginViewModel = new UserLogin()
            {
                RoleTypesList = new List<RoleEnum>() { RoleEnum.Queuer, RoleEnum.Server }
            };

            return View(userLoginViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                userService.InsertUser(new User(username: "bencami", password:"Hello123!", email: "camilleriben@gmail.com", roles: new List<RoleEnum>{ RoleEnum.Queuer, RoleEnum.Server }));

                if (userService.IsValid(userLogin.Username, userLogin.Password))
                {

                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View();
        }
    }
}
