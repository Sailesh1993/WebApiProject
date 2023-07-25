using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebProject.Dto;
using WebProject.Entities;

namespace WebProject
{
    public class AutoMapperProfile: Profile // automapper will look for all derived classes of profile and add to application
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}