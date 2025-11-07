using Hw17.Models.Database;
using Hw17.Models.Dtos;
using Hw17.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hw17.Controllers
{
    public class AccountController : Controller
    {
        private readonly Userservice _userService;

        public AccountController()
        {
            _userService = new Userservice();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto dto)
        {
            var result = _userService.Register(dto);
            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View(dto);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto dto)
        {
            var user = _userService.Login(dto.Username, dto.Password);

            if (user == null)
            {
                ViewBag.Error = "نام کاربری یا رمز عبور اشتباه است.";
                return View(dto);
            }

            InMemoryDatabase.LoggedInUser = user;

            if (user.IsAdmin)
                return RedirectToAction("Index", "Admin");
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
