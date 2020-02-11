using Microsoft.AspNetCore.Identity;
using PlanGeneratorDto.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanGeneratorRepository.Contracts
{
    public interface ILoginRepository
    {
        Task<IdentityUser> AddUser(LoginDto user);
        Task<IdentityUser> LoginUser(LoginDto user);
    }
}
