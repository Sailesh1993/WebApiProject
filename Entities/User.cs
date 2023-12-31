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
    public class User: BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Ignore]
        public byte[] Password { get; set; }
        public Address Address{ get; set; }
    }
}