using Hw17.Models.Entities;

namespace Hw17.Models.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();

        public Category? GetById(int id);

        public void UpdateName(int id, string newName);

        public void Delete(int id);

        public void Add(Category category);

    }
}
