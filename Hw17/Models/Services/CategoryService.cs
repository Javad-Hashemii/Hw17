using Hw17.Models.Dtos;
using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Repositories;
using Hw17.Models.Interfaces.Services;
using Hw17.Models.Repositories;
using System.Security.AccessControl;

namespace Hw17.Models.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService()
        {
            _categoryRepo = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            var categories = _categoryRepo.GetCategories();
            if (categories == null || categories.Count == 0)
                throw new Exception("هیچ دسته‌بندی‌ای یافت نشد.");
            return categories;
        }

        public ResultDto Add(string name, string imageUrl)
        {
            var newCategory = new Category
            {
                Name = name,
                ImageUrl = imageUrl
            };

            _categoryRepo.Add(newCategory);

            return new ResultDto { IsSuccess = true, Message = "دسته‌بندی با موفقیت اضافه شد." };
        }

        public ResultDto Delete(int id)
        {
            _categoryRepo.Delete(id);
            return new ResultDto { IsSuccess = true, Message = "دسته‌بندی حذف شد." };
        }

        public ResultDto UpdateName(int id, string newName)
        {
            _categoryRepo.UpdateName(id, newName);
            return new ResultDto { IsSuccess = true, Message = "نام دسته‌بندی ویرایش شد." };
        }

    }
}
