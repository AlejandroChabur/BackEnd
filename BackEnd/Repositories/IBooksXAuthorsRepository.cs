using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public interface IBooksXAuthorsRepository
    {
        private readonly TestDbContext _context;

        public BooksXAuthorsRepository(TestDbContext context)
        {
            _context = context;
        }

        // Obtener todas las relaciones entre libros y autores
        public async Task<List<BooksXAuthors>> GetAllBooksXAuthorsAsync()
        {
            return await _context.BooksXAuthors.ToListAsync();
        }

        // Obtener una relación específica por BookId
        public async Task<BooksXAuthors> GetBooksXAuthorsByBookIdAsync(int bookId)
        {
            var booksXAuthors = await _context.BooksXAuthors
                .FirstOrDefaultAsync(ba => ba.BookId == bookId); // Suponiendo que BookId se usa como identificador

            if (booksXAuthors == null)
            {
                throw new KeyNotFoundException($"BooksXAuthors with Book ID {bookId} not found.");
            }

            return booksXAuthors; // Devuelve la instancia de BooksXAuthors encontrada
        }

        // Crear una nueva relación entre un libro y un autor
        public async Task CreateBooksXAuthorsAsync(BooksXAuthors booksXAuthors)
        {
            await _context.BooksXAuthors.AddAsync(booksXAuthors);
            await _context.SaveChangesAsync();
        }

        // Actualizar una relación existente
        public async Task UpdateBooksXAuthorsAsync(BooksXAuthors booksXAuthors)
        {
            _context.BooksXAuthors.Update(booksXAuthors);
            await _context.SaveChangesAsync();
        }

        // Eliminar una relación entre un libro y un autor
        public async Task SoftDeleteBooksXAuthorsAsync(int bookId, int idPersona)
        {
           await_BooksXAuthorsRepository.SoftDeleteBooksXAuthorsAsync(bookId, idPersona);
        }
    }
}
