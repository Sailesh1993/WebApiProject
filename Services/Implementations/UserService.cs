using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebProject.Dto;
using WebProject.Entities;
using WebProject.Repositories.Abstractions;
using WebProject.Services.Abstractions;

namespace WebProject.Services.Implementations
{
    /*  having different Dtos: UserReadDto, UserCreateDto */
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;

        public UserService(IMapper mapper, IUserRepo userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public UserDto CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Password = Encoding.UTF8.GetBytes(userDto.Password);
            var createdUser = _userRepo.CreateUser(user);
            var createdUserDto =  _mapper.Map<UserDto>(createdUser);
            createdUserDto.Password = Encoding.UTF8.GetString(createdUser.Password);
            return createdUserDto;
        }

        public UserDto GetUserById(Guid id)
        {
            var foundUser = _userRepo.GetUserById(id);
            return _mapper.Map<UserDto>(foundUser);
        }

        public UserDto UpdateUser(Guid id, UserDto userDto)
        {
            Console.WriteLine("user service start");
            var foundUser = _userRepo.GetUserById(id) ?? throw new Exception("user not found");
            Console.WriteLine($"foundUser name:{foundUser.Name}");
            if(userDto.Name == null || (userDto.Name ==""))
            {
                userDto.Name = foundUser.Name;
            }
            if(userDto.Email == null || (userDto.Email ==""))
            {
                userDto.Email = foundUser.Email;
            }
            Console.WriteLine("user service update");
            var updatedUser = _userRepo.UpdateUser(foundUser,userDto);
            var updatedDto = _mapper.Map<UserDto>(updatedUser);
            updatedDto.Password = userDto.Password;
            return updatedDto;
        }
    }
}