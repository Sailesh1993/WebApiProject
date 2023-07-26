using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using WebProject.Dto;

namespace WebProject.Entities
{
    [AutoMap(typeof(UserDto))]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Ignore]
        public string Password { get; set; }
        public DateOnly createdAt{ get; set; }
        public DateOnly updatedAt{ get; set; }
    }
}