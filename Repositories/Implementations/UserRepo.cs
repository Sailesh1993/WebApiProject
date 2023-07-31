using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProject.Database;
using WebProject.Dto;
using WebProject.Entities;
using WebProject.Repositories.Abstractions;

namespace WebProject.Repositories.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly DbSet<User> _users; // represent data from 'Users' table   
        private readonly DatabaseContext _context;

        public UserRepo(DatabaseContext context)
        {
            _users = context.Users;
            _context = context;
        }
        public User CreateUser(User user)
        {
            _users.Add(user);
            // Console.WriteLine(_context.ChangeTracker.Entries().Count());
            Console.WriteLine(_context.ChangeTracker.Entries().FirstOrDefault().State);
            _context.SaveChanges();
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(Guid id)
        {
            return _users.Find(id);
        }
        public User UpdateUser(User user, UserDto update)
        {
                Console.WriteLine(_context.ChangeTracker.Entries().FirstOrDefault().State);
                user.Name = update.Name;
                user.Email = update.Email;
                user.Password = Encoding.UTF8.GetBytes(update.Password);
                Console.WriteLine(_context.ChangeTracker.Entries().FirstOrDefault().State);
                _context.SaveChanges();
                return user;
        }
    }
}