namespace BackEnd.Repositories 
{ 
using BackEnd; // Importa el modelo donde tienes la entidad Books
using global::BackEnd.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public interface IBooksRepository
    {
        // Obtener todos los libros
        Task<IEnumerable<Books>> GetAllBooksAsync();

        // Obtener un libro por su ID
        Task<Books?> GetBookByIdAsync(int id);

        // Crear un nuevo libro
        Task CreateBookAsync(Books book);

        // Actualizar un libro existente
        Task UpdateBookAsync(Books book);

        // Borrado lógico de un libro por su ID
        Task SoftDeleteBookAsync(int id);
    }
} }
