using System.Linq;
using DatingApp.API.Database;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using DatingApp.API.Services;

namespace DatingApp.API.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountsController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        
        [HttpPost("register")]
        public ActionResult<string> Register(RegisterDto register)
        {
            register.Username.ToLower();
            if (_context.Users.Any(u => u.Username == register.Username))
            {
                return BadRequest("Username is existed !");
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = register.Username,
                Email = register.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            if (_context.SaveChanges() > 0)
            {
                return Ok( new UserResponse(){
                    Username = user.Username,
                    Token = _tokenService.CreateToken(user)
                } );
            }
            else
            {
                return Ok("fail");
            }

        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username.ToLower());
            if (user == null)
            {
                return Unauthorized("Username not found!");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for(var i = 0; i< computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid password!");
                }
            }
            return Ok( new UserResponse(){
                    Username = user.Username,
                    Token = _tokenService.CreateToken(user)
            } );
        }

    }
}