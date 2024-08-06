using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces.Authentication;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;
using YuriiPasternak.SimpleRealEstate.WebAPI.Contracts;

namespace YuriiPasternak.SimpleRealEstate.WebAPI.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public AuthenticationController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register(RegisterRequest registerDto)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(registerDto);

            user.UserName = registerDto.UserName.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Client");

            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            var userRoles = await _userManager.GetRolesAsync(user);

            var setEmailResult = await _userManager.SetEmailAsync(user, registerDto.UserName);

            if (!setEmailResult.Succeeded) return BadRequest(setEmailResult.Errors);

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.UserName, user.FirstName, user.LastName, user.Email, userRoles.FirstOrDefault());

            return new AuthenticationResponse(
                user.Id,
                user.UserName,
                user.FirstName,
                user.LastName,
                user.Email,
                userRoles.FirstOrDefault(),
                token);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user == null) return Unauthorized("Invalid username");

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return Unauthorized("Invalid password");

            var userRoles = await _userManager.GetRolesAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.UserName, user.FirstName, user.LastName, user.Email, userRoles.FirstOrDefault());

            return new AuthenticationResponse(
               user.Id,
               user.UserName,
               user.FirstName,
               user.LastName,
               user.Email,
               userRoles.FirstOrDefault(),
               token);
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
