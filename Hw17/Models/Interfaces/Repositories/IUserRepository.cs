using Hw17.Models.Dtos;
using Hw17.Models.Entities;

namespace Hw17.Models.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public void Add(User user);

        public UserDto? GetByCredentials(string username, string password);

        public List<UserDto> GetAll();

        public void Delete(int id);

        public bool UsernameExists(string username);

        public void DeactivateUser(int id);

        public void ActivateUser(int id);

    }
}
