using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHashingDemo.DTOs;
using PasswordHashingDemo.Services;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost]
        //Adds the new user data in database
        public IActionResult Add(UserDto userDto)
        {
            if(!ModelState.IsValid)
            {
                var errors = string.Join(" ; ", ModelState.Values.SelectMany(v=>v.Errors).Select(v=>v.ErrorMessage));
                throw new ValidationException($"{ errors }");
            }
            var newUserId = _userService.Add(userDto);
            return Ok(newUserId);
        }

        [HttpPost("Login")]
        //Login with the help of credentials
        public IActionResult Login(LoginDto loginDto)
        {
            var isLogin = _userService.CheckPassword(loginDto);
            if (isLogin)
            {
                return Ok("Login Successful");
            }
            return BadRequest("Invalid Credentials");
        }
    }
}
