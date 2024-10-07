using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories
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
                .Include(a => a.Edition)
                .Where(a => !a.IsDelete)
                .ToListAsync();
        }

        public async Task<Books> GetBooksByIdAsync(int id)
        {
            var book = await _context.Books
                 .Include(a => a.Edition)
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
                book.IsDelete = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateBooksAsync(Books book)
        {
            // Busca la edición existente
            var edition = await _context.Editions
                .FindAsync(book.IdEdition); // Asegúrate de que estás usando el ID correcto

            if (edition == null)
            {
                // Si no existe, puedes lanzar una excepción o manejarlo de otra manera
                throw new Exception("Edición no encontrada");
            }

            // Asigna la edición encontrada al nuevo registro de Books
            book.Edition = edition;

            // Ahora agrega el nuevo registro de Books
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateBooksAsync(Books book)
        {
            // Busca el libro existente
            var existingBook = await _context.Books.FindAsync(book.Id);

            if (existingBook != null)
            {
                // Solo actualiza las propiedades necesarias
                existingBook.IdEdition = book.IdEdition;
                existingBook.Title = book.Title;
                existingBook.Code = book.Code;
                existingBook.PublicationYear = book.PublicationYear;

                // Guarda los cambios
                await _context.SaveChangesAsync();
            }
            else
            {
                // Puedes lanzar una excepción o manejar el caso donde el libro no se encuentra
                throw new KeyNotFoundException($"El libro con ID {book.Id} no se encontró.");
            }
        }


    }
}
