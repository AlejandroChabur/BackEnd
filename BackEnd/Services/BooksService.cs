using BackEnd.Model;
using BackEnd.Repositories.BackEnd.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Books>> GetAllBooksAsync();
        Task<Books?> GetBookByIdAsync(int id);
        Task CreateBookAsync(Books book);
        Task UpdateBookAsync(Books book);
        Task SoftDeleteBookAsync(int id);
    }



namespace BackEnd.Services
    {
        public class BooksService : IBooksService
        {
            private readonly IBooksRepository _booksRepository;

            public BooksService(IBooksRepository booksRepository)
            {
                _booksRepository = booksRepository;
            }

            public async Task<IEnumerable<Books>> GetAllBooksAsync()
            {
                return await _booksRepository.GetAllBooksAsync();
            }

            public async Task<Books?> GetBookByIdAsync(int id)
            {
                return await _booksRepository.GetBookByIdAsync(id);
            }

            public async Task CreateBookAsync(Books book)
            {
                await _booksRepository.CreateBookAsync(book);
            }

            public async Task UpdateBookAsync(Books book)
            {
                await _booksRepository.UpdateBookAsync(book);
            }

            public async Task SoftDeleteBookAsync(int id)
            {
                await _booksRepository.SoftDeleteBookAsync(id);
            }
        }
    }

}
