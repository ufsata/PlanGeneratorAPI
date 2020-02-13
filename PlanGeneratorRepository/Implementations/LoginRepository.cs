using Microsoft.AspNetCore.Identity;
using PlanGeneratorDataAccess;
using PlanGeneratorDto.Login;
using PlanGeneratorRepository.Contracts;
using System;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Implementations
{
    public class LoginRepository : ILoginRepository
    {
        private readonly PlanGeneratorContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginRepository(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            PlanGeneratorContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityUser> AddUser(LoginDto user)
        {
            var newUser = new IdentityUser
            {
                UserName = user.Username,
                Email = user.Email,
            };

            await _userManager.CreateAsync(newUser, user.Password);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<IdentityUser> LoginUser(LoginDto user)
        {
            var newUser = new IdentityUser
            {
                UserName = user.Username,
                Email = user.Email,
            };

            var userToLogin = await _userManager.FindByNameAsync(user.Username);

            if (userToLogin != null)
            {
                //sign in
                var signInResult = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return newUser;
                }
            }
            throw new Exception("No such User");
        }
    }
}
