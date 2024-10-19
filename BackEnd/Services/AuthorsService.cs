using BackEnd.Model;
using BackEnd.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace BackEnd.Services
{
    public class AuthorsServices 
    {
        private readonly AuthorsRepository _authorsRepository;

        // Constructor para inyectar el repositorio de autores
        public AuthorsServices(AuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        // Método para obtener un autor por su ID
        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            return await _authorsRepository.GetAuthorByIdAsync(id);
        }

        // Método para obtener todos los autores
        public async Task<IEnumerable<Authors>> GetAllAuthorsAsync()
        {
            return await _authorsRepository.GetAllAuthorsAsync(); // Llama al repositorio para obtener todos los autores
        }

        // Método para crear un nuevo autor
        public async Task CreateAuthorAsync(Authors author)
        {
            await _authorsRepository.CreateAuthorAsync(author); // Utiliza el repositorio para crear un autor
        }

        // Método para actualizar un autor existente
        public async Task UpdateAuthorAsync(Authors author)
        {
            await _authorsRepository.UpdateAuthorAsync(author); // Llama al repositorio para actualizar el autor
        }

        // Método para eliminar un autor por su ID
        public async Task DeleteAuthorAsync(int id)
        {
           await _authorsRepository.DeleteAuthorAsync(id);
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
