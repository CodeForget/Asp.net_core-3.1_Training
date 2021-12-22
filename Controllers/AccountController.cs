using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.DTOs;
using web_api.Entities;
using web_api.Interface;

namespace web_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private DataContext _context { get; }
        private ITokenService _token { get; }
        public AccountController(DataContext Context, ITokenService tokenService)
        {
            _token= tokenService;
            _context = Context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {

            if (await UserExists(registerDto.username))
            {
                return BadRequest("Username already exists");

            }
            using var hmac = new HMACSHA512();

            var user = new appUser
            {
                userName = registerDto.username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password)),
                PasswordSalt = hmac.Key

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return new UserDto {
                UserName = user.userName,
                Token = _token.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string UserName)
        {
            return await _context.Users.AnyAsync(x => x.userName == UserName.ToLower());

        }
    }
}