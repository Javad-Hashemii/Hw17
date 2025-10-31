namespace Hw17.Models.Dtos
{
    public class AddBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
