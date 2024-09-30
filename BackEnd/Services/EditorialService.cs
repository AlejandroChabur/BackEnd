using BackEnd.Model;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public class EditorialsService
    {
        private readonly EditorialsRepository _editorialsRepository;

        public EditorialsService(EditorialsRepository editorialsRepository)
        {
            _editorialsRepository = editorialsRepository;
        }

        public async Task<Editorials> GetEditorialByIdAsync(int id)
        {
            return await _editorialsRepository.GetEditorialByIdAsync(id);
        }

        public async Task CreateEditorialAsync(Editorials editorial)
        {
            await _editorialsRepository.CreateEditorialAsync(editorial);
        }

        public async Task<IEnumerable<Editorials>> GetAllEditorialsAsync()
        {
            return await _editorialsRepository.GetAllEditorialsAsync();
        }

        public async Task UpdateEditorialAsync(Editorials editorial)
        {
            await _editorialsRepository.UpdateEditorialAsync(editorial);
        }

        public async Task DeleteEditorialAsync(int id)
        {
            await _editorialsRepository.DeleteEditorialAsync(id);
        }
    }
}
