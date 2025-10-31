using Hw17.Models.Entities;

namespace Hw17.Models.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();

    }
}
