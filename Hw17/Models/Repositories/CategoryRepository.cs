using Hw17.Models.Database;
using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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
            return _context.Categories
                .AsNoTracking()
                .ToList();
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Categories
                .Where(c => c.Id == id)
                .ExecuteDelete();
        }

        public void UpdateName(int id, string newName)
        {
            _context.Categories
                .Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(x => x.Name, newName));
        }

        public Category? GetById(int id)
        {
            return _context.Categories
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
