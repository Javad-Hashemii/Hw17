using Hw17.Models.Dtos;

namespace Hw17.Models.Interfaces.Services
{
    public interface IUserService
    {
        public ResultDto Delete(int id);
        public List<UserDto> GetAll();
        public UserDto? Login(string username, string password);
        public ResultDto Register(UserRegisterDto dto);

        public ResultDto DeactivateUser(int id);
        public ResultDto ActivateUser(int id);
    }
}
