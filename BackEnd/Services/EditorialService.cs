using BackEnd.Model;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public class EditorialsService
    {
        private readonly EditorialsRepository _EditorialsRepository;

        public EditorialsService(EditorialsRepository EditorialsRepository)
        {
            _EditorialsRepository = EditorialsRepository;
        }

        public async Task<Editorials> GetEditorialByIdAsync(int id)
        {
            return await _EditorialsRepository.GetEditorialByIdAsync(id);
        }

        public async Task CreateEditorialAsync(Editorials editorial)
        {
            await _EditorialsRepository.CreateEditorialAsync(editorial);
        }

        public async Task<IEnumerable<Editorials>> GetAllEditorialsAsync()
        {
            return await _EditorialsRepository.GetAllEditorialsAsync();
        }

        public async Task UpdateEditorialAsync(Editorials editorial)
        {
            await _EditorialsRepository.UpdateEditorialAsync(editorial);
        }

        public async Task DeleteEditorialAsync(int id)
        {
            await _EditorialsRepository.DeleteEditorialAsync(id);
        }
    }
}
