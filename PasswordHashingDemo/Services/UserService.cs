using AutoMapper;
using BCrypt.Net;
using PasswordHashingDemo.DTOs;
using PasswordHashingDemo.Exceptions;
using PasswordHashingDemo.Models;
using PasswordHashingDemo.Repositories;

namespace PasswordHashingDemo.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Guid Add(UserDto userDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(userDto.Password);//Encrypt the password using Bcrypt
            User user = _mapper.Map<User>(userDto);//Map the data is another format to store in database
            user.PasswordHash = hashedPassword;
            _repository.Add(user);
            return user.Id;
        }

        public bool CheckPassword(LoginDto loginDto)
        {
            var users= _repository.GetAll();
            var user = users.Where(u=>u.UserName==loginDto.UserName).FirstOrDefault();
            if (user == null)
                throw new UserNotFoundException("Invalid Credentials");
            var password = BCrypt.Net.BCrypt.EnhancedVerify(loginDto.Password, user.PasswordHash);//Verify the password is correct or not
            return password;
        }
    }
}
