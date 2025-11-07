using Hw17.Models.Database;
using Hw17.Models.Dtos;
using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Repositories;
using Hw17.Models.Interfaces.Services;
using Hw17.Models.Repositories;

namespace Hw17.Models.Services
{
    public class Userservice : IUserService
    {
        private IUserRepository _userRepo;

        public Userservice()
        {
            _userRepo = new UserRepository();
        }

        public ResultDto Register(UserRegisterDto dto)
        {
            if (_userRepo.UsernameExists(dto.Username))
                return new ResultDto { IsSuccess = false, Message = "نام کاربری تکراری است." };

            var newUser = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                IsAdmin = dto.IsAdmin,
                CreatedAt = DateTime.Now
            };

            _userRepo.Add(newUser);

            return new ResultDto { IsSuccess = true, Message = "ثبت‌نام با موفقیت انجام شد." };
        }

        public UserDto? Login(string username, string password)
        {
            var user = _userRepo.GetByCredentials(username, password);
            if (user != null)
            {
                InMemoryDatabase.LoggedInUser = user;
            }
            return user;
        }

        public List<UserDto> GetAll()
        {
            return _userRepo.GetAll();
        }

        public ResultDto Delete(int id)
        {
            _userRepo.Delete(id);
            return new ResultDto { IsSuccess = true, Message = "کاربر حذف شد." };
        }

        public ResultDto ActivateUser(int id)
        {
            _userRepo.ActivateUser(id);
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر فعال شد."
            };
        }

        public ResultDto DeactivateUser(int id)
        {
            _userRepo.DeactivateUser(id);
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر غیرفعال شد."
            };
        }
    }
}
