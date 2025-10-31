using Hw17.Models.Entities;

namespace Hw17.Models.Dtos
{
    public class HomeViewDto
    {
        public List<Category> Categories { get; set; }
        public List<Book> NewestBooks { get; set; }
    }
}
