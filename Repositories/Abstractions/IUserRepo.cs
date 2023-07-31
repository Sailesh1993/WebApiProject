using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Dto;
using WebProject.Entities;

namespace WebProject.Repositories.Abstractions
{
    public interface IUserRepo
    {
        IEnumerable<User>GetAllUsers();
        User GetUserById(Guid id);
        User CreateUser(User user);
        User UpdateUser(User user, UserDto update);

    }
}