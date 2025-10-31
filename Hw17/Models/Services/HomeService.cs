using Hw17.Models.Dtos;
using Hw17.Models.Interfaces.Repositories;
using Hw17.Models.Interfaces.Services;
using Hw17.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hw17.Models.Services
{
    public class HomeService:IHomeService
    {
        private ICategoryRepository _categoryRepo;
        private IBookRepository _bookRepository;

        public HomeService()
        {
            _categoryRepo = new CategoryRepository();
            _bookRepository = new BookRepository();
        }

        public HomeViewDto GetCategoriesAndBooks()
        {
            var model = new HomeViewDto
            {
                Categories = _categoryRepo.GetCategories(),
                NewestBooks = _bookRepository.GetBooksByNewestPublishedDate()
            };
            return model;
        }

    }
}
