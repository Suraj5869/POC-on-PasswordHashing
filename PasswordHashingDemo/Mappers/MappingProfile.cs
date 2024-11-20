using AutoMapper;
using PasswordHashingDemo.DTOs;
using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
