namespace Hw17.Models.Interfaces.Services
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);
    }
}
