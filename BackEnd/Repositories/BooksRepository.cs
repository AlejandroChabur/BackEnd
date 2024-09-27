using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public interface IBooksRepository
    {
        Task<Books> GetBooksByIdAsync(int id);
        Task<IEnumerable<Books>> GetAllBooksAsync();
        Task CreateBooksAsync(Books book);
        Task UpdateBooksAsync(Books book);
        Task DeleteBookAsync(int id);
    }

    public class BooksRepository : IBooksRepository
    {
        private readonly TestDbContext _context;

        public BooksRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            return await _context.Books
                .ToListAsync();
        }

        public async Task<Books> GetBooksByIdAsync(int id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            return book; // Devolver la instancia del libro encontrado
        }


        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateBooksAsync(Books book)
        {
            try
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al crear el libro: {e.Message}");
                throw; // Vuelve a lanzar la excepción después de registrar el error
            }
        }


        public async Task UpdateBooksAsync(Books book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
