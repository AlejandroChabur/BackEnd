using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class AuthorsServices : IAuthorsServices
    {
        private readonly TestDbContext _context;

        // Constructor para inyectar el contexto de la base de datos
        public AuthorsServices(TestDbContext context)
        {
            _context = context;
        }

        // Método para obtener un autor por su ID
        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.Id == id); // Cambia "Id" por el nombre correcto de la propiedad si es diferente

            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }

            return author; // Devuelve la instancia del autor encontrado
        }

        // Otros métodos que puedas necesitar para manejar autores
        public async Task<IEnumerable<Authors>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync(); // Devuelve todos los autores
        }

        public async Task CreateAuthorAsync(Authors author)
        {
            await _context.Authors.AddAsync(author); // Agrega un nuevo autor
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
        }

        public async Task UpdateAuthorAsync(Authors author)
        {
            _context.Authors.Update(author); // Actualiza el autor existente
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author); // Elimina el autor
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }
            else
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }
        }
    }
    public interface IAuthorsServices
    {
        Task<Authors> GetAuthorByIdAsync(int id);
        Task<IEnumerable<Authors>> GetAllAuthorsAsync();
        Task CreateAuthorAsync(Authors author);
        Task UpdateAuthorAsync(Authors author);
        Task DeleteAuthorAsync(int id);
    }
}