using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanGeneratorDto.Login;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanGeneratorAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoginRepository _loginRepository;


        public LoginController(UserManager<IdentityUser> userManager, ILoginRepository loginRepository)
        {
            _userManager = userManager;
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]LoginDto user)
        {
            await _loginRepository.AddUser(user);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginDto user)
        {
            await _loginRepository.LoginUser(user);
            return Json(new { success = true });
        }

        //[HttpGet]
        //public async Task<ActionResult<LoginDto>> GetUserByName()
        //{
        //    var userToReturn = await _loginRepository.GetUserByUsername();

        //    if (userToReturn == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(userToReturn);
        //}
    }
}
