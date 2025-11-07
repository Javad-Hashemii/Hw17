namespace Hw17.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string? ImageUrl { get; set; }

        public int Price { get; set; }

        public DateTime PublishedDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }
}
