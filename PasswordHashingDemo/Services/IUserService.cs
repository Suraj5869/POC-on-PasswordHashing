using PasswordHashingDemo.DTOs;
using PasswordHashingDemo.Models;
using PasswordHashingDemo.Repositories;

namespace PasswordHashingDemo.Services
{
    public interface IUserService
    {
        public bool CheckPassword(LoginDto loginDto);
        public Guid Add(UserDto userDto);
        
    }
}
