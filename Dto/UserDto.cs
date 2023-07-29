using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;

namespace WebProject.Dto
{
    public class UserDto
    {
       public string Name { get; set; }
        public string Email { get; set; }
        [Ignore]
        public string Password { get; set; } 
    }
}