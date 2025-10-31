using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Repositories;
using Hw17.Models.Interfaces.Services;
using Hw17.Models.Repositories;
using System.Security.AccessControl;

namespace Hw17.Models.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService()
        {
            _categoryRepo = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return _categoryRepo.GetCategories();
        }
    }
}
