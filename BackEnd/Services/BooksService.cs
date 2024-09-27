using BackEnd.Model;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public interface IBooksServices
    {
        Task<IEnumerable<Books>> GetAllBooksAsync();
        Task<Books> GetBooksByIdAsync(int id);
        Task CreateBooksAsync(Books book);
        Task UpdateBooksAsync(Books book);
        Task DeleteBooksAsync(int id);
    }

    public class BooksServices : IBooksServices
    {
        private readonly IBooksRepository _booksRepository;

        public BooksServices(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            return await _booksRepository.GetAllBooksAsync();
        }

        public async Task<Books> GetBooksByIdAsync(int id)
        {
            return await _booksRepository.GetBooksByIdAsync(id);
        }

        public async Task CreateBooksAsync(Books book)
        {
            await _booksRepository.CreateBooksAsync(book);
        }

        public async Task UpdateBooksAsync(Books book)
        {
            await _booksRepository.UpdateBooksAsync(book);
        }

        public async Task DeleteBooksAsync(int id)
        {
            await _booksRepository.DeleteBookAsync(id);
        }
    }
}

