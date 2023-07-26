using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebProject.Dto;
using WebProject.Entities;
using WebProject.Services.Abstractions;

namespace WebProject.Services.Implementations
{
    /*  having different Dtos: UserReadDto, UserCreateDto */
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly List<User> _users = new(){
            new User { Name = "Sailesh", Email="karki@gmail.com", Password={}, createdAt= new DateOnly(), Id=1},
            new User { Name = "KK", Email="kk@gmail.com", Password={}, createdAt=new DateOnly(), Id=2},
            new User { Name = "SK", Email="sk@gmail.com", Password={}, createdAt=new DateOnly(), Id=3},
        };
        
        public UserService(IMapper mapper){
            _mapper = mapper;
        }
        public UserDto CreateUser(UserDto userDto)
        {
            //var createdUser = new User { Name = userDto.Name, Email=userDto.Email, Password=userDto.Password};
            byte[] passwordByte = Encoding.UTF8.GetBytes(userDto.Password);
            var createdUser = _mapper.Map<User>(userDto); //convert userDto into User object
            Console.WriteLine($"Create: {createdUser.Name} with Id {createdUser.Id}");
            _users.Add(createdUser);
            Console.WriteLine(_users.Count); 
            return userDto;
        }

        public UserDto GetUserById(int id)
        {
            var foundUser = _users.FirstOrDefault(x => x.Id == id);
            //var userDto = new UserDto { Name = foundUser.Name, Email=foundUser.Email, Password=foundUser.Password};
            /* if(foundUser is null)
            {
                throw new Exception("error not found");
            } */
            var userDto = _mapper.Map<UserDto>(foundUser);
            return userDto;
        }
    }
}