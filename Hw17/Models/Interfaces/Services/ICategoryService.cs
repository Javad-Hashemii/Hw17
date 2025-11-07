using Hw17.Models.Dtos;
using Hw17.Models.Entities;

namespace Hw17.Models.Interfaces.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        public ResultDto Add(string name, string imageUrl);
        public ResultDto Delete(int id);
        public ResultDto UpdateName(int id, string newName);

    }
}
