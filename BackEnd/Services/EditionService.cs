using BackEnd.Model;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public class EditionService
    {
        private readonly EditionRepository _editionRepository;

        public EditionService(EditionRepository editionRepository)
        {
            _editionRepository = editionRepository;
        }

        // Obtener una edición por ID
        public async Task<Edition> GetEditionByIdAsync(int id)
        {
            return await _editionRepository.GetEditionByIdAsync(id);
        }

        // Crear una nueva edición
        public async Task CreateEditionAsync(Edition edition)
        {
            await _editionRepository.CreateEditionAsync(edition);
        }

        // Obtener todas las ediciones
        public async Task<IEnumerable<Edition>> GetAllEditionsAsync()
        {
            return await _editionRepository.GetAllEditionsAsync();
        }

        // Actualizar una edición
        public async Task UpdateEditionAsync(Edition edition)
        {
            await _editionRepository.UpdateEditionAsync(edition);
        }

        // Eliminar una edición
        public async Task DeleteEditionAsync(int id)
        {
            await _editionRepository.DeleteEditionAsync(id);
        }
    }
}
