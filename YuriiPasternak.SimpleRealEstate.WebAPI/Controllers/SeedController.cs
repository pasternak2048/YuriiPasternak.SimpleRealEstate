using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Context;

namespace YuriiPasternak.SimpleRealEstate.WebAPI.Controllers
{
    public class SeedController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SimpleRealEstateDbContext _dataContext;

        public SeedController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SimpleRealEstateDbContext dataContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }

        [HttpPost("SeedRoles")]
        public async Task<ActionResult> SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Client").Result)
            {
                var role = new AppRole();
                role.Name = "Client";
                await _roleManager.CreateAsync(role);
            }

            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new AppRole();
                role.Name = "Administrator";
                await _roleManager.CreateAsync(role);
            }

            if (!_roleManager.RoleExistsAsync("Superuser").Result)
            {
                var role = new AppRole();
                role.Name = "Superuser";
                await _roleManager.CreateAsync(role);
            }

            return Ok();
        }

        [HttpPost("SeedUsers")]
        public async Task<ActionResult> SeedUsers()
        {
            var user1 = new AppUser()
            {
                UserName = "ao@gmail.com",
                FirstName = "Olga",
                LastName = "Aleksandrovych",
                Email = "ao@gmail.com",
                EmailConfirmed = true
            };

            var user2 = new AppUser()
            {
                UserName = "su@gmail.com",
                FirstName = "Superuser",
                LastName = "Superuser",
                Email = "su@gmail.com",
                EmailConfirmed = true
            };

            var user3 = new AppUser()
            {
                UserName = "yp@gmail.com",
                FirstName = "Yurii",
                LastName = "Pasternak",
                Email = "yp@gmail.com",
                EmailConfirmed = true
            };

            var result1 = await _userManager.CreateAsync(user1, "11111111_Aa");
            if (result1.Succeeded)
            {
                //add this to add role to user
                await _userManager.AddToRoleAsync(user1, "Administrator");
            }

            var result2 = await _userManager.CreateAsync(user2, "11111111_Aa");
            if (result2.Succeeded)
            {
                //add this to add role to user
                await _userManager.AddToRoleAsync(user2, "Superuser");
            }

            var result3 = await _userManager.CreateAsync(user3, "11111111_Aa");
            if (result3.Succeeded)
            {
                //add this to add role to user
                await _userManager.AddToRoleAsync(user3, "Client");
            }

            return Ok();
        }
    }
}
