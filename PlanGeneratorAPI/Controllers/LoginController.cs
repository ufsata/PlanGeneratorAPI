using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanGeneratorDto.Login;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanGeneratorAPI.Controllers
{
    [Route("api/user")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoginRepository _loginRepository;
        private readonly ILogger<LoginController> _logger;

        public LoginController(UserManager<IdentityUser> userManager, ILoginRepository loginRepository, ILogger<LoginController> logger)
        {
            _userManager = userManager;
            _loginRepository = loginRepository;
            _logger = logger;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody]LoginDto user)
        {
            await _loginRepository.AddUser(user);
            return Json(new { success = true });
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginDto user)
        {
            try
            {
                await _loginRepository.LoginUser(user);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while logging in: {ex}");
            }
            return BadRequest("Failed to login");
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
