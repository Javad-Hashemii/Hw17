using Hw17.Models.Dtos;
using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Services;
using Hw17.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hw17.Controllers
{
    public class AdminController : Controller
    {
        private readonly Userservice _userService;
        private readonly CategoryService _categoryService;

        public AdminController()
        {
            _userService = new Userservice();
            _categoryService= new CategoryService();
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        public IActionResult Users()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Users");
        }

        [HttpPost]
        public IActionResult Activate(int id)
        {
            var result = _userService.ActivateUser(id);
            return RedirectToAction("Users");
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

            return RedirectToAction("Users");
        }


        [HttpPost]
        public IActionResult Deactivate(int id)
        {
            var result = _userService.DeactivateUser(id);
            return RedirectToAction("Users");
        }
        public IActionResult Categories()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Add(string name, string imageUrl)
        {
            var result = _categoryService.Add(name, imageUrl);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, string newName)
        {
            var result = _categoryService.UpdateName(id, newName);
            return RedirectToAction("Index");
        }

    }
}
