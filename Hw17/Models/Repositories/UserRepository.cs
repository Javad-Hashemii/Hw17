using Hw17.Models.Database;
using Hw17.Models.Dtos;
using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hw17.Models.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public UserDto? GetByCredentials(string username, string password)
        {
            return _context.Users
                .Where(u => u.Username == username && u.Password == password)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    IsAdmin = u.IsAdmin,
                    IsActive = u.IsActive,
                })
                .FirstOrDefault();
        }

        public void ActivateUser(int id)
        {
            _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdate(u => u.SetProperty(x => x.IsActive, true));
        }
        public void DeactivateUser(int id)
        {
            _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdate(u => u.SetProperty(x => x.IsActive, false));
        }

        public List<UserDto> GetAll()
        {
            return _context.Users
                .AsNoTracking()
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    IsAdmin = u.IsAdmin,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public bool UsernameExists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
    }
}
