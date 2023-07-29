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

        public UserDto GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}