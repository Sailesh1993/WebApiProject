using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using WebProject.Entities;

namespace WebProject.Dto
{
    [AutoMap(typeof(User))]
    public class UserDto
    {
       public string Name { get; set; }
        public string Email { get; set; }
        [Ignore]
        public string Password { get; set; } 
    }
}