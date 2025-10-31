using Hw17.Models.Database;
using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Repositories;

namespace Hw17.Models.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository()
        {
            _context = new AppDbContext();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
