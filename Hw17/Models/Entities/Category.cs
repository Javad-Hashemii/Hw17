using System.Diagnostics.Eventing.Reader;

namespace Hw17.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public List<Book> Books { get; set; }
    }
}
